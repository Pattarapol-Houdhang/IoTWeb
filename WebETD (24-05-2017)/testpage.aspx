<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpage.aspx.cs" Inherits="testpage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Admin Panel Template">
    <!-- styles -->
    <link href="css/bootstrap.css" tppabs="http://lab.westilian.com/alpona/css/bootstrap.css" rel="stylesheet">
    <link href="css/tablecloth.css" tppabs="http://lab.westilian.com/alpona/css/tablecloth.css" rel="stylesheet">
    <link href="css/font-alpona.css" tppabs="http://lab.westilian.com/alpona/css/font-alpona.css" rel="stylesheet">
    <link href="css/prettify.css" tppabs="http://lab.westilian.com/alpona/css/prettify.css" rel="stylesheet">
    <link href="css/responsive-tables.css" tppabs="http://lab.westilian.com/alpona/css/responsive-tables.css" rel="stylesheet">
    <link href="css/styles.css" tppabs="http://lab.westilian.com/alpona/css/styles.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" tppabs="http://lab.westilian.com/alpona/css/bootstrap-reset.css" rel="stylesheet">
    <!--fav and touch icons -->
    <link rel="shortcut icon" href="ico/favicon.ico" tppabs="http://lab.westilian.com/alpona/ico/favicon.ico">
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="ico/apple-touch-icon-144-precomposed.png.gif" tppabs="http://lab.westilian.com/alpona/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="ico/apple-touch-icon-114-precomposed.png.gif" tppabs="http://lab.westilian.com/alpona/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="ico/apple-touch-icon-72-precomposed.png.gif" tppabs="http://lab.westilian.com/alpona/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="ico/apple-touch-icon-57-precomposed.png.gif" tppabs="http://lab.westilian.com/alpona/ico/apple-touch-icon-57-precomposed.png">
    <script src="js/jquery.js" tppabs="http://lab.westilian.com/alpona/js/jquery.js"></script>
    <!--[if lt IE 9]>
        <script src="js/respond.min.js"></script>
        <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="main-wrapper">
            <div class="scroll-top">
                <a href="#" class="tip-top" title="Go Top"><i class="icon-arrow-up"></i></a>
            </div>
            <!-- TOP BAR -->
            <div class="top-bar">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-4 col-md-4">
                            <a href="#" class="left-toggle"><i class="icon-menu-2 "></i></a>
                            <!-- LOGO -->
                            <div class="branding">
                                <a href="index.html" tppabs="http://lab.westilian.com/alpona/index.html">
                                    <img src="images/alpona-logo.png" tppabs="http://lab.westilian.com/alpona/images/alpona-logo.png" alt="Alpona Logo"></a>
                            </div>
                        </div>
                        <div class="col-sm-4 col-md-4 responsive-notification-mnu">
                            <ul class="notification-bar">
                                <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="icon-bell"></i></a>
                                    <div class="dropdown-menu">
                                        <div class="dropdown-head">
                                            <h6>You have 10 new notifications</h6>
                                        </div>
                                        <ul class="notification-list">
                                            <li><a href="#" class="clearfix"><i class="icon-star blue"></i><span class="notification-intro">Donec pretium enim vel nisl viverra posuere.<span class="notification-time">8 min ago</span></span></a></li>
                                            <li><a href="#" class="clearfix"><i class=" icon-bell orange"></i><span class="notification-intro">Vestibulum viverra magna vitae dui volutpat dapibus. <span class="notification-time">3 hours ago</span></span></a></li>
                                            <li><a href="#" class="clearfix"><i class=" icon-bolt brown"></i><span class="notification-intro">Fusce eget ipsum in odio consectetur condimentum et id nisl.<span class="notification-time">5 hours ago</span></span></a></li>
                                            <li><a href="#" class="clearfix"><i class=" icon-ok-sign green"></i><span class="notification-intro">Mauris fringilla metus in mauris molestie tempor <span class="notification-time">8 hours ago</span></span></a></li>
                                        </ul>
                                        <div class="action-btn">
                                            <button class="btn btn-block">View All</button>
                                        </div>
                                    </div>
                                </li>
                                <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="count-noty">12</span><i class="icon-envelop-opened"></i></a>
                                    <div class="dropdown-menu">
                                        <div class="dropdown-head">
                                            <h6>You have 32 new messages</h6>
                                        </div>
                                        <ul class="msg-list">
                                            <li class="clearfix"><a href="#"><span class="dropdown-thumb">
                                                <img width="40" height="40" alt="Avatar" src="images/avatar-40x40/binjal.png" tppabs="http://lab.westilian.com/alpona/images/avatar-40x40/binjal.png"></span><span><i>binjal</i> is posted an article. lacus est congue... </span><span class="notification-meta">12 hours ago </span></a></li>
                                            <li class="clearfix"><a href="#"><span class="dropdown-thumb">
                                                <img width="40" height="40" alt="Avatar" src="images/avatar-40x40/sharmin.png" tppabs="http://lab.westilian.com/alpona/images/avatar-40x40/sharmin.png"></span><span><i>sharmin</i> is posted an article. lacus est congue... </span><span class="notification-meta">12 hours ago </span></a></li>
                                            <li class="clearfix"><a href="#"><span class="dropdown-thumb">
                                                <img width="40" height="40" alt="Avatar" src="images/avatar-40x40/shusi.png" tppabs="http://lab.westilian.com/alpona/images/avatar-40x40/shusi.png"></span><span><i>shusi</i> is posted an article. lacus est congue... </span><span class="notification-meta">12 hours ago </span></a></li>
                                            <li class="clearfix"><a href="#"><span class="dropdown-thumb">
                                                <img width="40" height="40" alt="Avatar" src="images/avatar-40x40/jamjam.png" tppabs="http://lab.westilian.com/alpona/images/avatar-40x40/jamjam.png"></span><span><i>jamjam</i> is posted an article. lacus est congue... </span><span class="notification-meta">12 hours ago </span></a></li>
                                            <li class="clearfix"><a href="#"><span class="dropdown-thumb">
                                                <img width="40" height="40" alt="Avatar" src="images/avatar-40x40/sinha.png" tppabs="http://lab.westilian.com/alpona/images/avatar-40x40/sinha.png"></span><span><i>sinha</i> is posted an article. lacus est congue... </span><span class="notification-meta">12 hours ago </span></a></li>
                                        </ul>
                                        <div class="action-btn">
                                            <button class="btn btn-block">View All</button>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <div class="col-sm-4 col-md-4 clearfix responsive-log-mnu">
                            <!-- ADMIN DRODOWN MENU -->
                            <div class="loged-nav pull-right">
                                <ul class="clearfix">
                                    <li class="log-nav dropdown pull-right"><a class="dropdown-toggle clearfix" data-toggle="dropdown">
                                        <span class="pull-left loged-user-name">Sharmin Sultana</span><span class="logged-user-thumb pull-right"><img class="img-circle" src="images/admin-avatar.jpg" tppabs="http://lab.westilian.com/alpona/images/admin-avatar.jpg" alt="Admin"></span></a>
                                        <div class="dropdown-menu">
                                            <ul class="pull-right">
                                                <li><a href="#">kjamanebr@gmail.com</a></li>
                                                <li><a href="#">Edit Profile</a></li>
                                                <li><a href="#">Inbox</a></li>
                                                <li class="divider"></li>
                                                <li><a href="#" class="logout-link"><i class="icon-lock-3"></i>Logout</a></li>
                                            </ul>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- LEFT BAR -->
            <div class="left-bar merge-left">
                <!-- SEARCH BAR -->
                <div class="search-bar">
                    <div class="input-group">
                        <input type="text" class="form-control">
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button"><i class="icon-search"></i></button>
                        </span>
                    </div>
                </div>
                <!-- LEFT NAV -->
                <div class="left-nav">
                    <ul class="side-navigation accordion" id="nav-accordion">
                        <li><a href="index.html" tppabs="http://lab.westilian.com/alpona/index.html"><i class="icon-home"></i>Home</a></li>
                        <li><a href="#"><i class="icon-list-alt"></i>Forms</a>
                            <ul>
                                <li><a href="form-elements.html" tppabs="http://lab.westilian.com/alpona/form-elements.html"><i class="icon-double-angle-right"></i>All Form Elements</a></li>
                                <li><a href="extended-form-elements.html" tppabs="http://lab.westilian.com/alpona/extended-form-elements.html"><i class="icon-double-angle-right"></i>Extended Form Elements <span class="nav-instruction">Lots of plugins is used here</span></a></li>
                                <li><a href="form-validation.html" tppabs="http://lab.westilian.com/alpona/form-validation.html"><i class="icon-double-angle-right"></i>Form Validation</a></li>
                                <li><a href="form-wizard.html" tppabs="http://lab.westilian.com/alpona/form-wizard.html"><i class="icon-double-angle-right"></i>Stepy Form</a></li>
                            </ul>
                        </li>
                        <li><a href="#"><i class="icon-table-2"></i>Tables</a>
                            <ul>
                                <li><a href="basic-table.html" tppabs="http://lab.westilian.com/alpona/basic-table.html"><i class="icon-double-angle-right"></i>Basic Tables <span class="nav-instruction">This is an instruction</span></a></li>
                                <li><a href="table-themes.html" tppabs="http://lab.westilian.com/alpona/table-themes.html"><i class="icon-double-angle-right"></i>Tables-Theme</a></li>
                                <li><a href="data-tables.html" tppabs="http://lab.westilian.com/alpona/data-tables.html"><i class="icon-double-angle-right"></i>Data Tables</a></li>
                            </ul>
                        </li>
                        <li><a href="#"><i class="icon-columns"></i>Grid/Portlets</a>
                            <ul>
                                <li><a href="boxy-grids-porlets.html" tppabs="http://lab.westilian.com/alpona/boxy-grids-porlets.html"><i class="icon-double-angle-right"></i>Boxy Grid/Portlets <span class="nav-instruction">This is an instruction</span></a></li>
                                <li><a href="non-boxy-grids-porlets.html" tppabs="http://lab.westilian.com/alpona/non-boxy-grids-porlets.html"><i class="icon-double-angle-right"></i>Non Boxy Grid/Portlets</a></li>
                            </ul>
                        </li>
                        <li><a href="#"><i class="icon-laptop"></i>Layout &AMP; Dashboard</a>
                            <ul>
                                <li><a href="blank-layout.html" tppabs="http://lab.westilian.com/alpona/blank-layout.html"><i class="icon-double-angle-right"></i>Blank Layout <span class="nav-instruction">This is an instruction</span></a></li>
                                <li><a href="fixed-topbar.html" tppabs="http://lab.westilian.com/alpona/fixed-topbar.html"><i class="icon-double-angle-right"></i>Fixed Topbar</a></li>
                                <li><a href="fixed-leftbar.html" tppabs="http://lab.westilian.com/alpona/fixed-leftbar.html"><i class="icon-double-angle-right"></i>Fixed Leftbar</a></li>
                                <li><a href="top-dropdown-menu.html" tppabs="http://lab.westilian.com/alpona/top-dropdown-menu.html"><i class="icon-double-angle-right"></i>Top Dropdown Menu</a></li>
                                <li><a href="no-sidebar.html" tppabs="http://lab.westilian.com/alpona/no-sidebar.html"><i class="icon-double-angle-right"></i>No Sidebar</a></li>
                            </ul>
                        </li>
                        <li><a href="#"><i class="icon-font"></i>Typography</a>
                            <ul>
                                <li><a href="typography-boxy.html" tppabs="http://lab.westilian.com/alpona/typography-boxy.html"><i class="icon-double-angle-right"></i>Boxy Typography <span class="nav-instruction">This is an instruction</span></a></li>
                                <li><a href="typography-non-boxy.html" tppabs="http://lab.westilian.com/alpona/typography-non-boxy.html"><i class="icon-double-angle-right"></i>Non Boxy Typography</a></li>
                            </ul>
                        </li>
                        <li><a href="#"><i class="icon-cord"></i>UI Elements</a>
                            <ul>
                                <li><a href="bootstrap-ui.html" tppabs="http://lab.westilian.com/alpona/bootstrap-ui.html"><i class="icon-double-angle-right"></i>Bootstrap UI <span class="nav-instruction">This is an instruction</span></a></li>
                                <li><a href="jquery-ui.html" tppabs="http://lab.westilian.com/alpona/jquery-ui.html"><i class="icon-double-angle-right"></i>jQuery UI</a></li>
                                <li><a href="extended-ui-elements.html" tppabs="http://lab.westilian.com/alpona/extended-ui-elements.html"><i class="icon-double-angle-right"></i>Extended Elements<span class="nav-instruction"> More Cool UI elements plugins </span></a></li>
                            </ul>
                        </li>
                        <li><a href="#"><i class="icon-tools"></i>Components &AMP; Plugins</a>
                            <ul>
                                <li><a href="buttons-icons.html" tppabs="http://lab.westilian.com/alpona/buttons-icons.html"><i class="icon-double-angle-right"></i>Buttons &AMP; Icons</a></li>
                                <li><a href="wysiwyg.html" tppabs="http://lab.westilian.com/alpona/wysiwyg.html"><i class="icon-double-angle-right"></i>WYSIWYG Text Editor</a></li>
                                <li><a href="calendar.html" tppabs="http://lab.westilian.com/alpona/calendar.html"><i class="icon-double-angle-right"></i>Calendar</a></li>
                                <li><a href="flot-chart.html" tppabs="http://lab.westilian.com/alpona/flot-chart.html"><i class="icon-double-angle-right"></i>Flot Chart</a></li>
                                <li><a href="google-chart.html" tppabs="http://lab.westilian.com/alpona/google-chart.html"><i class="icon-double-angle-right"></i>Google Chart</a></li>
                            </ul>
                        </li>
                        <li><a href="#"><i class="icon-files"></i>Example Pages</a>
                            <ul>
                                <li><a href="content-post.html" tppabs="http://lab.westilian.com/alpona/content-post.html"><i class="icon-double-angle-right"></i>Content Post</a></li>
                                <li><a href="login.html" tppabs="http://lab.westilian.com/alpona/login.html"><i class="icon-double-angle-right"></i>Login</a></li>
                                <li><a href="product-list.html" tppabs="http://lab.westilian.com/alpona/product-list.html"><i class="icon-double-angle-right"></i>Products List</a></li>
                                <li><a href="gallery.html" tppabs="http://lab.westilian.com/alpona/gallery.html"><i class="icon-double-angle-right"></i>Gallery Page</a></li>
                                <li><a href="search-page.html" tppabs="http://lab.westilian.com/alpona/search-page.html"><i class="icon-double-angle-right"></i>Search Page</a></li>
                                <li><a href="error-page.html" tppabs="http://lab.westilian.com/alpona/error-page.html"><i class="icon-double-angle-right"></i>Error Page</a></li>
                                <li><a href="invoice-page.html" tppabs="http://lab.westilian.com/alpona/invoice-page.html"><i class="icon-double-angle-right"></i>Invoice</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <!-- SITE CONTAINER -->
            <div class="main-container">
                <div class="container">
                    <div class="page-header">
                        <h1><i class="icon-table-2"></i>Basic Tables <small>All default tables style</small></h1>
                    </div>
                    <ul class="breadcrumb">
                        <li><a href="#"><i class="icon-home"></i></a></li>
                        <li><a href="#">Library</a></li>
                        <li class="active">Basic Tables</li>
                    </ul>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="intro-block">
                                <div class="element-header">
                                    <h4>Table - 01 <small>table in boxy widget, boxy bordered table with dropdown menu.</small></h4>
                                </div>
                                <p>
                                    Estibulum nibh lorem, blandit non pretium sit amet, tempus eget ipsum. Quisque auctor pretium turpis nec elementum. Quisque egestas lectus nec eros ornare et eleifend dui adipiscing. Vestibulum non ipsum libero. Curabitur eu ligula dolor. Nulla sed rutrum tortor. Ut metus risus, consequat nec laoreet vel, congue eget odio. Fusce eu massa neque, posuere tempor ligula. Nam ac commodo libero. Vivamus quis posuere elit.
                                </p>
                            </div>
                            <div class="box-widget">
                                <div class="widget-head clearfix">
                                    <span class="h-icon"><i class="icon-power-cord"></i></span>
                                    <h4 class="pull-left">Table Head</h4>
                                    <div class="table-action dropdown pull-right">
                                        <a data-toggle="dropdown" class="dropdown-toggle" href="#"><i class="icon-cog"></i></a>
                                        <ul class="dropdown-menu pull-right">
                                            <li><a href="#"><i class="icon-plus-2 "></i>Add Row</a></li>
                                            <li><a href="#"><i class=" icon-remove-sign"></i>Suspend</a></li>
                                            <li><a href="#"><i class=" icon-ok"></i>Approved</a></li>
                                            <li><a href="#"><i class=" icon-remove-3"></i>Delete</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="widget-container">
                                    <div class="widget-block">
                                        <div class="widget-content">
                                            <table class="table responsive">
                                                <thead>
                                                    <tr>
                                                        <th>OrderDate
                                                        </th>
                                                        <th>Region
                                                        </th>
                                                        <th>Rep
                                                        </th>
                                                        <th>Item
                                                        </th>
                                                        <th>Units
                                                        </th>
                                                        <th>Unit Cost
                                                        </th>
                                                        <th>Total
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>1/6/10
                                                        </td>
                                                        <td>Quebec
                                                        </td>
                                                        <td>Jones
                                                        </td>
                                                        <td>Pencil
                                                        </td>
                                                        <td>95
                                                        </td>
                                                        <td>1.99
                                                        </td>
                                                        <td>189.05
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>1/23/10
                                                        </td>
                                                        <td>Ontario
                                                        </td>
                                                        <td>Kivell
                                                        </td>
                                                        <td>Binder
                                                        </td>
                                                        <td>50
                                                        </td>
                                                        <td>19.99
                                                        </td>
                                                        <td>999.50
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>2/9/10
                                                        </td>
                                                        <td>Ontario
                                                        </td>
                                                        <td>Jardine
                                                        </td>
                                                        <td>Pencil
                                                        </td>
                                                        <td>36
                                                        </td>
                                                        <td>4.99
                                                        </td>
                                                        <td>179.64
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="intro-block">
                                <div class="element-header">
                                    <h4>Table - 02 <small>boxy bordered table with data stats and dropdown menu.</small></h4>
                                </div>
                                <p>
                                    Estibulum nibh lorem, blandit non pretium sit amet, tempus eget ipsum. Quisque auctor pretium turpis nec elementum. Quisque egestas lectus nec eros ornare et eleifend dui adipiscing. Vestibulum non ipsum libero. Curabitur eu ligula dolor. Nulla sed rutrum tortor. Ut metus risus, consequat nec laoreet vel, congue eget odio. Fusce eu massa neque, posuere tempor ligula. Nam ac commodo libero. Vivamus quis posuere elit.
                                </p>
                            </div>
                            <div class="data-meta clearfix">
                                <ul>
                                    <li><a href="#"><i class="icon-list-4"></i>View All (30)</a></li>
                                    <li><a href="#"><i class="icon-file-check-2 "></i>Publish (20)</a></li>
                                    <li><a href="#"><i class=" icon-remove-3"></i>Trush (10)</a></li>
                                </ul>
                            </div>
                            <div class="box-widget">
                                <div class="widget-head clearfix">
                                    <div class="tbl-search-bar pull-left">
                                        <form action="#" method="get">
                                            <ul>
                                                <li>
                                                    <select name="" class="search-select form-control">
                                                        <option value="Select">Select</option>
                                                        <option value="Select 1">Select 1</option>
                                                    </select>
                                                </li>
                                                <li>
                                                    <button class="btn" type="submit">Button </button>
                                                </li>
                                            </ul>
                                        </form>
                                    </div>
                                    <div class="table-action dropdown pull-right">
                                        <a data-toggle="dropdown" class="dropdown-toggle" href="#"><i class="icon-cog"></i></a>
                                        <ul class="dropdown-menu pull-right">
                                            <li><a href="#"><i class="icon-plus-2 "></i>Add Row</a></li>
                                            <li><a href="#"><i class=" icon-remove-sign"></i>Suspend</a></li>
                                            <li><a href="#"><i class=" icon-ok"></i>Approved</a></li>
                                            <li><a href="#"><i class=" icon-remove-3"></i>Delete</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="widget-container">
                                    <div class="widget-block">
                                        <div class="widget-content">
                                            <table class="table responsive">
                                                <thead>
                                                    <tr>
                                                        <th>OrderDate
                                                        </th>
                                                        <th>Region
                                                        </th>
                                                        <th>Rep
                                                        </th>
                                                        <th>Item
                                                        </th>
                                                        <th>Units
                                                        </th>
                                                        <th>Unit Cost
                                                        </th>
                                                        <th>Total
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>1/6/10
                                                        </td>
                                                        <td>Quebec
                                                        </td>
                                                        <td>Jones
                                                        </td>
                                                        <td>Pencil
                                                        </td>
                                                        <td>95
                                                        </td>
                                                        <td>1.99
                                                        </td>
                                                        <td>189.05
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>1/23/10
                                                        </td>
                                                        <td>Ontario
                                                        </td>
                                                        <td>Kivell
                                                        </td>
                                                        <td>Binder
                                                        </td>
                                                        <td>50
                                                        </td>
                                                        <td>19.99
                                                        </td>
                                                        <td>999.50
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>2/9/10
                                                        </td>
                                                        <td>Ontario
                                                        </td>
                                                        <td>Jardine
                                                        </td>
                                                        <td>Pencil
                                                        </td>
                                                        <td>36
                                                        </td>
                                                        <td>4.99
                                                        </td>
                                                        <td>179.64
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="intro-block">
                                <div class="element-header">
                                    <h4>Tables<small></small></h4>
                                </div>
                                <p>
                                    Estibulum nibh lorem, blandit non pretium sit amet, tempus eget ipsum. Quisque auctor pretium turpis nec elementum. Quisque egestas lectus nec eros ornare et eleifend dui adipiscing. Vestibulum non ipsum libero. Curabitur eu ligula dolor. Nulla sed rutrum tortor. Ut metus risus, consequat nec laoreet vel, congue eget odio. Fusce eu massa neque, posuere tempor ligula. Nam ac commodo libero. Vivamus quis posuere elit.
                                </p>
                            </div>
                            <div class="square-widget">
                                <div class="widget-container">
                                    <div class="data-meta clearfix">
                                        <ul>
                                            <li><a href="#"><i class="icon-list-4"></i>View All (30)</a></li>
                                            <li><a href="#"><i class="icon-file-check-2 "></i>Publish (20)</a></li>
                                            <li><a href="#"><i class=" icon-remove-3"></i>Trush (10)</a></li>
                                        </ul>
                                    </div>
                                    <div class="search-pane clearfix">
                                        <div class="tbl-search-bar pull-left">
                                            <form action="#" method="get">
                                                <ul>
                                                    <li>
                                                        <select name="" class="search-select form-control">
                                                            <option value="Select">Select</option>
                                                            <option value="Select 1">Select 1</option>
                                                        </select>
                                                    </li>
                                                    <li>
                                                        <button class="btn" type="submit">Button </button>
                                                    </li>
                                                </ul>
                                            </form>
                                        </div>
                                        <div class="dropdown pull-right table-action-btn">
                                            <a data-toggle="dropdown" class="dropdown-toggle btn" href="#"><i class="icon-cog"></i></a>
                                            <ul class="dropdown-menu pull-right">
                                                <li><a href="#"><i class="icon-plus-2 "></i>Add Row</a></li>
                                                <li><a href="#"><i class=" icon-remove-sign"></i>Suspend</a></li>
                                                <li><a href="#"><i class=" icon-ok"></i>Approved</a></li>
                                                <li><a href="#"><i class=" icon-remove-3"></i>Delete</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <table class="table responsive">
                                        <thead>
                                            <tr>
                                                <th>OrderDate
                                                </th>
                                                <th>Region
                                                </th>
                                                <th>Rep
                                                </th>
                                                <th>Item
                                                </th>
                                                <th>Units
                                                </th>
                                                <th>Unit Cost
                                                </th>
                                                <th>Total
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1/6/10
                                                </td>
                                                <td>Quebec
                                                </td>
                                                <td>Jones
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>95
                                                </td>
                                                <td>1.99
                                                </td>
                                                <td>189.05
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>1/23/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Kivell
                                                </td>
                                                <td>Binder
                                                </td>
                                                <td>50
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>999.50
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/9/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Jardine
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>36
                                                </td>
                                                <td>4.99
                                                </td>
                                                <td>179.64
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="square-widget">
                                <div class="widget-head clearfix">
                                    <h4 class="pull-left">Default Style</h4>
                                </div>
                                <div class="widget-container">
                                    <table class="table responsive">
                                        <thead>
                                            <tr>
                                                <th>OrderDate
                                                </th>
                                                <th>Region
                                                </th>
                                                <th>Rep
                                                </th>
                                                <th>Item
                                                </th>
                                                <th>Units
                                                </th>
                                                <th>Unit Cost
                                                </th>
                                                <th>Total
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1/6/10
                                                </td>
                                                <td>Quebec
                                                </td>
                                                <td>Jones
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>95
                                                </td>
                                                <td>1.99
                                                </td>
                                                <td>189.05
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>1/23/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Kivell
                                                </td>
                                                <td>Binder
                                                </td>
                                                <td>50
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>999.50
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/9/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Jardine
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>36
                                                </td>
                                                <td>4.99
                                                </td>
                                                <td>179.64
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/26/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Gill
                                                </td>
                                                <td>Pen
                                                </td>
                                                <td>27
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>539.73
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="square-widget">
                                <div class="widget-head clearfix">
                                    <h4 class="pull-left">Table with optional classes</h4>
                                </div>
                                <div class="widget-container">
                                    <table class="table responsive">
                                        <thead>
                                            <tr>
                                                <th>OrderDate
                                                </th>
                                                <th>Region
                                                </th>
                                                <th>Rep
                                                </th>
                                                <th>Item
                                                </th>
                                                <th>Units
                                                </th>
                                                <th>Unit Cost
                                                </th>
                                                <th>Total
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="success">
                                                <td>1/6/10
                                                </td>
                                                <td>Quebec
                                                </td>
                                                <td>Jones
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>95
                                                </td>
                                                <td>1.99
                                                </td>
                                                <td>189.05
                                                </td>
                                            </tr>
                                            <tr class="error">
                                                <td>1/23/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Kivell
                                                </td>
                                                <td>Binder
                                                </td>
                                                <td>50
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>999.50
                                                </td>
                                            </tr>
                                            <tr class="info">
                                                <td>2/9/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Jardine
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>36
                                                </td>
                                                <td>4.99
                                                </td>
                                                <td>179.64
                                                </td>
                                            </tr>
                                            <tr class="warning">
                                                <td>2/26/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Gill
                                                </td>
                                                <td>Pen
                                                </td>
                                                <td>27
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>539.73
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="square-widget">
                                <div class="widget-head clearfix">
                                    <h4 class="pull-left">Striped Table</h4>
                                </div>
                                <div class="widget-container">
                                    <table class="table table-striped responsive">
                                        <thead>
                                            <tr>
                                                <th>OrderDate
                                                </th>
                                                <th>Region
                                                </th>
                                                <th>Rep
                                                </th>
                                                <th>Item
                                                </th>
                                                <th>Units
                                                </th>
                                                <th>Unit Cost
                                                </th>
                                                <th>Total
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1/6/10
                                                </td>
                                                <td>Quebec
                                                </td>
                                                <td>Jones
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>95
                                                </td>
                                                <td>1.99
                                                </td>
                                                <td>189.05
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>1/23/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Kivell
                                                </td>
                                                <td>Binder
                                                </td>
                                                <td>50
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>999.50
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/9/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Jardine
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>36
                                                </td>
                                                <td>4.99
                                                </td>
                                                <td>179.64
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/26/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Gill
                                                </td>
                                                <td>Pen
                                                </td>
                                                <td>27
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>539.73
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="square-widget">
                                <div class="widget-head clearfix">
                                    <h4 class="pull-left">Striped Table with table hover</h4>
                                </div>
                                <div class="widget-container">
                                    <table class="table table-striped table-hover responsive">
                                        <thead>
                                            <tr>
                                                <th>OrderDate
                                                </th>
                                                <th>Region
                                                </th>
                                                <th>Rep
                                                </th>
                                                <th>Item
                                                </th>
                                                <th>Units
                                                </th>
                                                <th>Unit Cost
                                                </th>
                                                <th>Total
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1/6/10
                                                </td>
                                                <td>Quebec
                                                </td>
                                                <td>Jones
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>95
                                                </td>
                                                <td>1.99
                                                </td>
                                                <td>189.05
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>1/23/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Kivell
                                                </td>
                                                <td>Binder
                                                </td>
                                                <td>50
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>999.50
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/9/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Jardine
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>36
                                                </td>
                                                <td>4.99
                                                </td>
                                                <td>179.64
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/26/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Gill
                                                </td>
                                                <td>Pen
                                                </td>
                                                <td>27
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>539.73
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="square-widget">
                                <div class="widget-head clearfix">
                                    <h4 class="pull-left">Bordered Table</h4>
                                </div>
                                <div class="widget-container">
                                    <table class="table table-bordered responsive">
                                        <thead>
                                            <tr>
                                                <th>OrderDate
                                                </th>
                                                <th>Region
                                                </th>
                                                <th>Rep
                                                </th>
                                                <th>Item
                                                </th>
                                                <th>Units
                                                </th>
                                                <th>Unit Cost
                                                </th>
                                                <th>Total
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1/6/10
                                                </td>
                                                <td>Quebec
                                                </td>
                                                <td>Jones
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>95
                                                </td>
                                                <td>1.99
                                                </td>
                                                <td>189.05
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>1/23/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Kivell
                                                </td>
                                                <td>Binder
                                                </td>
                                                <td>50
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>999.50
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/9/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Jardine
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>36
                                                </td>
                                                <td>4.99
                                                </td>
                                                <td>179.64
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/26/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Gill
                                                </td>
                                                <td>Pen
                                                </td>
                                                <td>27
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>539.73
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="square-widget">
                                <div class="widget-head clearfix">
                                    <h4 class="pull-left">Compact Table</h4>
                                </div>
                                <div class="widget-container">
                                    <table class="table table-condensed responsive">
                                        <thead>
                                            <tr>
                                                <th>OrderDate
                                                </th>
                                                <th>Region
                                                </th>
                                                <th>Rep
                                                </th>
                                                <th>Item
                                                </th>
                                                <th>Units
                                                </th>
                                                <th>Unit Cost
                                                </th>
                                                <th>Total
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1/6/10
                                                </td>
                                                <td>Quebec
                                                </td>
                                                <td>Jones
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>95
                                                </td>
                                                <td>1.99
                                                </td>
                                                <td>189.05
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>1/23/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Kivell
                                                </td>
                                                <td>Binder
                                                </td>
                                                <td>50
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>999.50
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/9/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Jardine
                                                </td>
                                                <td>Pencil
                                                </td>
                                                <td>36
                                                </td>
                                                <td>4.99
                                                </td>
                                                <td>179.64
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2/26/10
                                                </td>
                                                <td>Ontario
                                                </td>
                                                <td>Gill
                                                </td>
                                                <td>Pen
                                                </td>
                                                <td>27
                                                </td>
                                                <td>19.99
                                                </td>
                                                <td>539.73
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="js/jquery-ui-1.10.3.custom.min.js" tppabs="http://lab.westilian.com/alpona/js/jquery-ui-1.10.3.custom.min.js"></script>
        <script src="js/bootstrap.min.js" tppabs="http://lab.westilian.com/alpona/js/bootstrap.min.js"></script>
        <script src="js/prettify.js" tppabs="http://lab.westilian.com/alpona/js/prettify.js"></script>
        <!--jQuery touch scroll -->
        <script src="js/jquery.nicescroll.js" tppabs="http://lab.westilian.com/alpona/js/jquery.nicescroll.js"></script>
        <script src="js/jquery.cookie.js" tppabs="http://lab.westilian.com/alpona/js/jquery.cookie.js"></script>
        <script src="js/jquery.hoverIntent.minified.js" tppabs="http://lab.westilian.com/alpona/js/jquery.hoverIntent.minified.js"></script>
        <!--jQuery leftbar navigation accordion -->
        <script src="js/jquery.dcjqaccordion.2.7.js" tppabs="http://lab.westilian.com/alpona/js/jquery.dcjqaccordion.2.7.js"></script>
        <!--jQuery Responsive Table -->
        <script src="js/responsive-tables.js" tppabs="http://lab.westilian.com/alpona/js/responsive-tables.js"></script>
        <!-- Theme common script -->

        <script src="js/common-script.js" tppabs="http://lab.westilian.com/alpona/js/common-script.js"></script>
        <!--[if lte IE 7]>
                                <script src="js/font-alpona-ie7.js"></script>
                <![endif]-->
    </form>
</body>
</html>
