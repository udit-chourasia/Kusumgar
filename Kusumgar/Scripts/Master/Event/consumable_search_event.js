﻿$(function () {

    //InitializeAutoComplete($('#txtCustomer_Name'), autoConsumableCallback);

    $('#hdfCurrentPage').val(0);

    SearchAllConsumable();

    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);
        SearchAllConsumable();
    });

  
    $("#btnEdit").click(function () {

        $("#frmSearchConsumableMaster").attr("action", "/master/edit-consumable");

        $("#frmSearchConsumableMaster").attr("method", "POST");

        $("#frmSearchConsumableMaster").submit();
    });

    
});


