﻿
$(function () {

    $("#hdnIs_Active").val(true);

    $("#hdnIs_Approved_By_Director").val(true);

    $('#dtpExpiration_Date_Of_Contract').datepicker();

    if ($("#hdnCompany_Id").val() == 0) {
        $("#Financial_Tab").hide();
        $("#Billing_Tab").hide();
        $("#Shipping_Tab").hide();
        $("#Other_Tab").hide();
    }

    $("#btn_Save").click(function () {
       
        if ($("#frm_Customer").valid()) {

            Save_Customer_Details();
        }
    });

    $("#btnSaveOther").click(function () {

        if ($("#frm_other").valid()) {
            Save_Customer_Details();
        }
    });

    $('[name="chkStatus"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

    $('[name="chkIsApproved"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Approved_By_Director").val(true);
        }
        else {
            $("#hdnIs_Approved_By_Director").val(false);
        }
    });

    $('[name="chkAutoMailDelivery"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnAuto_Mail_Delivery").val(true);
        }
        else {
            $("#hdnAuto_Mail_Delivery").val(false);
        }
    });

    $('[name="chkBlockOrder"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnBlock_Order").val(true);
        }
        else {
            $("#hdnBlock_Order").val(false);
        }
    });

    $('[name="Public_Private"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            if(this.id == "rdPublic")
            {
                $("#hdnPublic_Private_Sector").val(true);
            }
            else
            {
                $("#hdnPublic_Private_Sector").val(false);
            }
        }
        
    });

    $('[name="Organised_Unorganised"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            if (this.id == "rdOrgnised") {
                $("#hdnOrganised_UnOrganised_Sector").val(true);
            }
            else
            {
                $("#hdnOrganised_UnOrganised_Sector").val(false);
            }
        }
    });

    $('[name="Company_Type"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
                $("#hdnProprietary_Private_Limited").val($(this).val());
            }
            else {
            $("#hdnProprietary_Private_Limited").val($(this).val());
            }
    });

    $('[name="Company_Status"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnProgressive_Stable_Turmoil").val($(this).val());
        }
        else {
            $("#hdnProgressive_Stable_Turmoil").val($(this).val());
        }
    });


    $("#drpHead_Office_Nation").change(function () {
       
        $.ajax({
            url: '/crm/state-by-nation-id',
            data: { Nation_Id: $("#drpHead_Office_Nation").val() },
            method: 'GET',
            async: false,
            success: function (data) {
                if (data != null) {
                    Bind_State_Data(data);
                }
            }
        });
    });


});