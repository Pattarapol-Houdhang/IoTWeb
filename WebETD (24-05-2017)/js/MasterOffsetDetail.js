$(document).ready(function () {
    
    var _item = [
                    "crank_shaft", "piston", "cylinder",
                    "front_head", "rear_head", "swing_bush"
                ];
    var i;

    $(".item-block").click(function () {
        var type = $(this).data("type");
        $(".sub_menu_item").fadeOut(0);
        
        for (i = 0; i < _item.length; i++) {
            if (_item[i] == type) {
                $("." + type).fadeIn(0);
            }
        }

        if ($("#sub-menu").is(":visible")) {
            if ($("#hidType").val() == type) {
                $("#sub-menu").fadeOut(100);
            } else {
                $("#sub-menu").fadeIn(100);
            }
        } else {
            $("#sub-menu").fadeIn(100);
        }

        $("#hidType").val(type);  // set type value
    });




});