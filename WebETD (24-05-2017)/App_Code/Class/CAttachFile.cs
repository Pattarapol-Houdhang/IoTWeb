using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CAttachFile
/// </summary>
public class CAttachFile
{
    public void DeleteFile(string inPathFile)
    {
        try
        {
            File.Delete(inPathFile);
        }
        catch (Exception ex)
        {
            
        }
    }

    public string SaveFile(HttpPostedFile file, string BasePath, FileUpload inFileUpload)
    {
        try
        {
            // Specify the path to save the uploaded file to.
            string savePath = BasePath;

            // Get the name of the file to upload.
            string fileName = inFileUpload.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if ((System.IO.File.Exists(pathToCheck)))
            {
                int counter = 2;
                while ((System.IO.File.Exists(pathToCheck)))
                {
                    // If a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter = counter + 1;
                }
                fileName = tempfileName;

            }
            else
            {
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            inFileUpload.SaveAs(savePath);

            return savePath;
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public string SaveFile(HttpPostedFile file, string BasePath, FileUpload inFileUpload, string inData)
    {

        try
        {
            // Specify the path to save the uploaded file to.
            string savePath = BasePath;

            // Get the name of the file to upload.
            //Dim fileName As String = inFileUpload.FileName
            string fileName = inData.Replace("\"","");

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if ((System.IO.File.Exists(pathToCheck)))
            {
                int counter = 2;
                while ((System.IO.File.Exists(pathToCheck)))
                {
                    // If a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter = counter + 1;
                }
                fileName = tempfileName;

            }
            else
            {
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            inFileUpload.SaveAs(savePath);

            return savePath;
        }
        catch (Exception ex)
        {
            return "";
        }


    }

    public byte[] GetStreamData(HttpPostedFile filPosted)
    {
        int intFileLength = System.Convert.ToInt32(filPosted.ContentLength);
        byte[] byteData = new byte[intFileLength];
        filPosted.InputStream.Read(byteData, 0, intFileLength);
        return byteData;
    }

    public byte[] GetStreamData(string inPathFile)
    {
        FileStream inputStream = new FileStream(inPathFile, FileMode.Open);
        byte[] byteData = new byte[Convert.ToInt32(inputStream.Length - 1) + 1];
        inputStream.Read(byteData, 0, Convert.ToInt32(inputStream.Length));

        //Dim intFileLength As Integer = System.Convert.ToInt32(filPosted.)
        //Dim byteData As Byte() = New Byte(intFileLength - 1) {}
        //filPosted.InputStream.Read(byteData, 0, intFileLength)
        inputStream.Close();
        return byteData;

    }

    public string GetShortFileName(string fileName)
    {
        string result = "";
        if (fileName.Length >= 0)
        {
            int indexOfSlash = 0;
            int indexOfBackSlash = 0;
            indexOfSlash = fileName.LastIndexOf("/");
            indexOfBackSlash = fileName.LastIndexOf("\\");
            if (indexOfSlash > 0)
            {
                result = fileName.Substring(indexOfSlash + 1);
            }
            else if (indexOfBackSlash > 0)
            {
                result = fileName.Substring(indexOfBackSlash + 1);
            }
            else
            {
                result = fileName;
            }
        }
        return result;
    }
    public void GetAttachFile(byte[] dataFile, string fileName, System.Web.HttpResponse resPonsding)
    {
        resPonsding.ClearContent();
        resPonsding.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        BinaryWriter bw = new BinaryWriter(resPonsding.OutputStream);
        bw.Write(dataFile);
        bw.Close();
        resPonsding.ContentType = ReturnExtension(GetExtensionFile(fileName));
        resPonsding.End();
    }

    public string GetExtensionFile(string fileName)
    {
        string result = "";
        if (fileName.Length >= 0)
        {
            int indexOfDot = 0;
            indexOfDot = fileName.LastIndexOf(".");
            if (indexOfDot > 0)
            {
                result = fileName.Substring(indexOfDot);
            }
        }
        return result;
    }

    private string ReturnExtension(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }
}