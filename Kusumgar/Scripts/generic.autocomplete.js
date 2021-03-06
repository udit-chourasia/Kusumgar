﻿
var InitializeAutoComplete = function (elementObject) {


    $(elementObject).autocomplete({
        source: function (request, response) {

            var urlString = ''

            if ($(elementObject).attr("id") == 'txtCustomer_Name') {
                urlString = "/customer/customer-list/" + $('#txtCustomer_Name').val();
            }
            if ($(elementObject).attr("id") == 'txtCustName') {
                urlString = "/crm/get-customer-id-by-customername/" + $('#txtCustName').val();
            }
            if ($(elementObject).attr("id") == 'txtVendorName') {
                urlString = "/master/get-vendor-id-by-vendorname/" + $('#txtVendorName').val();
            }

            if ($(elementObject).attr("id") == 'txt_auto_Vendor_Name') {
                urlString = "/master/get-vendor-id-by-vendorname/" + $('#txt_auto_Vendor_Name').val();
            }

            if ($(elementObject).attr("id") == 'txtSupplierName') {
                urlString = "/master/vendor-list/" + $('#txtSupplierName').val();
            }

            if ($(elementObject).attr("id") == 'txtVendor_Name') {
                urlString = "/master/vendors-list/" + $('#txtVendor_Name').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit1') {

                urlString = "/ajax/test/" + $('#txtTestUnit1').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit2') {
                urlString = "/ajax/test/" + $('#txtTestUnit2').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit3') {
                urlString = "/ajax/test/" + $('#txtTestUnit3').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit4') {
                urlString = "/ajax/test/" + $('#txtTestUnit4').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit5') {
                urlString = "/ajax/test/" + $('#txtTestUnit5').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit6') {
                urlString = "/ajax/test/" + $('#txtTestUnit6').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit7') {
                urlString = "/ajax/test/" + $('#txtTestUnit7').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit8') {

                urlString = "/ajax/test/" + $('#txtTestUnit8').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit9') {
                urlString = "/ajax/test/" + $('#txtTestUnit9').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit10') {
                urlString = "/ajax/test/" + $('#txtTestUnit10').val();
            }


            if ($(elementObject).attr("id") == 'txtGiven_By') {
                urlString = "/master/search-employee-by-name/" + $('#txtGiven_By').val();
            }

            if ($(elementObject).attr("id") == 'txtValidated_By') {
                urlString = "/master/search-employee-by-name/" + $('#txtValidated_By').val();
            }

            if ($(elementObject).attr("id") == 'txtDeveloped_Under') {
                urlString = "/master/search-employee-by-name/" + $('#txtDeveloped_Under').val();
            }

            if ($(elementObject).attr("id") == 'txtEmployeeName') {
                urlString = "/master/search-employee-by-name/" + $('#txtEmployeeName').val();
            }

            if ($(elementObject).attr("id") == 'txtRole_Name') {
                urlString = "/master/search-role-by-name//" + $('#txtRole_Name').val();
            }

            if ($(elementObject).attr("id") == 'txtYArticle_Full_Code') {
                urlString = "/master/y-articles-by-full-code/" + $('#txtYArticle_Full_Code').val();
            }

            if ($(elementObject).attr("id") == 'txtWork_Center') {
                urlString = "/master/y-articles/get-work-centers-by-code-purpose/" + $('#txtWork_Center').val();
            }

            if ($(elementObject).attr("id") == 'txtMaterialName') {
                urlString = "/master/get-material-by-material-name/" + $('#txtMaterialName').val();
            }

            if ($(elementObject).attr("id") == 'txtDefectTypeName') {
                urlString = "/ajax/defect-type-list/" + $('#txtDefectTypeName').val();
            }


            if ($(elementObject).attr("id") == 'txtDefectName') {
                urlString = "/ajax/defect-list/" + $('#txtDefectName').val();
            }

            if ($(elementObject).attr("id") == 'txtApplicationName') {
                urlString = "/ajax/application-list/" + $('#txtApplicationName').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnitName') {
                urlString = "/ajax/test-unit-list/" + $('#txtTestUnitName').val();
            }

            if ($(elementObject).attr("id") == 'txtMarketSegmentName') {
                urlString = "/ajax/segment-list/" + $('#txtMarketSegmentName').val();
            }

            if ($(elementObject).attr("id") == 'txtQuality_No') {
                urlString = "/sales/quality-autocomplete/" + $('#txtQuality_No').val();
            }

            if ($(elementObject).attr("id") == 'txtPArticle_Full_Code') {
                urlString = "/master/p-articles-by-full-code/" + $('#txtPArticle_Full_Code').val();
            }

            if ($(elementObject).attr("id") == 'txtCustomer_Sample_No') {
                urlString = "/master/sample-no-list/" + $('#txtCustomer_Sample_No').val();
            }


            if ($(elementObject).attr("id") == 'txtGArticle_Full_Code') {
                urlString = "/master/g-articles-by-full-code/" + $('#txtGArticle_Full_Code').val();
            }

            if ($(elementObject).attr("id") == 'txtProcessName') {
                urlString = "/master/get-process-id-by-process-name/" + $('#txtProcessName').val();
            }

            if ($(elementObject).attr("id") == 'txtWArticle_FullCode') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWArticle_FullCode').val();
            }

            if ($(elementObject).attr("id") == 'txtCArticle_FullCode') {
                urlString = "/master/c-articles-by-full-code/" + $('#txtCArticle_FullCode').val();
            }

            //
            if ($(elementObject).attr("id") == 'txtWarp_1') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWarp_1').val();
            }

            if ($(elementObject).attr("id") == 'txtWarp_2') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWarp_2').val();
            }

            if ($(elementObject).attr("id") == 'txtWarp_3') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWarp_3').val();
            }

            if ($(elementObject).attr("id") == 'txtWarp_4') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWarp_4').val();
            }

            if ($(elementObject).attr("id") == 'txtWeft_1') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWeft_1').val();
            }

            if ($(elementObject).attr("id") == 'txtWeft_2') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWeft_2').val();
            }

            if ($(elementObject).attr("id") == 'txtWeft_3') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWeft_3').val();
            }

            if ($(elementObject).attr("id") == 'txtWeft_4') {
                urlString = "/master/w-articles-by-full-code/" + $('#txtWeft_4').val();
            }

            if ($(elementObject).attr("id") == 'txtCustomer_Approved_Sample') {
                urlString = "/master/sample-no-list/" + $('#txtCustomer_Approved_Sample').val();
            }
            //


            if ($(elementObject).attr("id") == 'txtPackingName') {
                urlString = "/master/get-packing-id-by-packing-name/" + $('#txtPackingName').val();
            }

            $.ajax({
                url: urlString,
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Label,
                            value: item.Value
                        }
                    }));
                }
            });
        },

        minLength: 2,
        focus: function (event, ui) {
            $(this).val(ui.item.label);
            return false;
        },
        select: function (event, ui) {

            $(this).val(ui.item.label);

            //$(this).parent().find('input[type=text]').val("");
            //$(this).parent().find('input[type=hidden]').val(ui.item.value);

            //if ($(this).parent().find(".todo-list")[0]) {
            //    $(this).parent().find('.todo-list').remove();
            //}

            //var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + ui.item.label + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            //if ($(this).parent().find(".ui-menu")[0]) {

            //    $(this).parent().find('.text').html(ui.item.label);
            //} else {

            //    $(this).parent().append(htmlText);
            //}

            //$('.fa-remove').click(function (event) {
            //    event.preventDefault();
            //    $(this).parent().parent().parent().parent().find('input[type=text]').val("");
            //    $(this).parent().parent().parent().parent().find('input[type=hidden]').val("");
            //    $(this).parent().parent().parent().parent().find('.todo-list').remove();
            //});
            ////callBack(ui);

            $(this).parents('.form-group').find('input[type=text]').val("");
            $(this).parents('.form-group').find('.auto-complete-value').val(ui.item.value);
            $(this).parents('.form-group').find('.auto-complete-label').val(ui.item.label);

            $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
            $(this).parents('.form-group').find('.auto-complete-label').trigger('change');

            if ($(this).parents('.form-group').find(".todo-list")[0]) {
                $(this).parents('.form-group').find('.todo-list').remove();
            }

            var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + ui.item.label + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            if ($(this).parents('.form-group').find(".ui-menu")[0]) {

                $(this).parents('.form-group').find('.text').html(ui.item.label);
            } else {

                $(this).parents('.form-group').append(htmlText);
            }

            $(this).parents('.form-group').find('.fa-remove').click(function (event) {
                event.preventDefault();
                $(this).parents('.form-group').find('input[type=text]').val("");
                $(this).parents('.form-group').find('.auto-complete-value').val("");
                $(this).parents('.form-group').find('.auto-complete-label').val("");
                $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
                $(this).parents('.form-group').find('.auto-complete-label').trigger('change');
                $(this).parents('.form-group').find('.todo-list').remove();
            });

            $('.ui-autocomplete').html("");
            return false;
        },
        open: function () {
            //$(this).removeClass("ui-corner-all").addClass("ui-corner-top");
            $(this).removeClass("ui-corner-all").addClass("ui-sortable");
        },
        close: function (event, ui) {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");

        }
    });

    $(elementObject).each(function () {
       
        //if ($(this).parents('.form-group').find('input[type=hidden]').val() != 0) {
        //    var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text' value='" + $(this).val() + "' name=''>" + $(this).val() + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";
        //    //var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + ui.item.label + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

        //    if ($(this).parents('.form-group').find(".ui-menu")[0]) {

        //        $(this).parents('.form-group').find('.text').html(ui.item.label);
        //    } else {

        //        $(this).parents('.form-group').append(htmlText);
        //    }

        //    $(this).parents('.form-group').find('input[type=text]').val("");

        //    $('.fa-remove').click(function (event) {
        //        event.preventDefault();
        //        $(this).parents('.form-group').find('input[type=text]').val("");
        //        $(this).parents('.form-group').find('input[type=hidden]').val("");
        //        $(this).parents('.form-group').find('.todo-list').remove();

        //    });
        //}
        //else
        //{
        //    $(this).parents('.form-group').find('.todo-list').remove();
        //}

        if ($(this).parents('.form-group').find('.auto-complete-value').val() != 0) {

            var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + $(this).parents('.form-group').find('.auto-complete-label').val() + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            if ($(this).parents('.form-group').find(".ui-menu")[0]) {

                $(this).parents('.form-group').find('.text').html(ui.item.label);
            } else {

                $(this).parents('.form-group').append(htmlText);
            }

            $(this).parents('.form-group').find('input[type=text]').val("");

            $(this).parents('.form-group').find('.fa-remove').click(function (event) {
                event.preventDefault();
                $(this).parents('.form-group').find('input[type=text]').val("");
                $(this).parents('.form-group').find('.auto-complete-value').val("");
                $(this).parents('.form-group').find('.auto-complete-label').val("");
                $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
                $(this).parents('.form-group').find('.auto-complete-label').trigger('change');
                $(this).parents('.form-group').find('.todo-list').remove();

            });
        }
        else {
            $(this).parents('.form-group').find('.todo-list').remove();
        }
    });
}