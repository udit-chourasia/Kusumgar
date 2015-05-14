﻿$(document).ready(function () {

    GetAllTests();

    $("#btnSearch").click(function () {
        SearchTests();
    });

    $('#btnEdit').click(function () {

        $("#frmTestSearch").attr("action", "/Test/GetTestById");

        $("#frmTestSearch").attr("method", "post");

        $("#frmTestSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

    $('#drpFabricTypeName').change(function () {

        $('#hdfFabricTypeId').val($('#drpFabricTypeName :selected').val());
       
    })

    if ($("#hdfFabricTypeId").val() != 0) {
       
        $('#drpFabricTypeName').val($("#hdfFabricTypeId").val());
    }

});