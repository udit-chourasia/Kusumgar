﻿$(function () {

    InitializeAutoComplete($('#txtFull_Code'));

    $('#hdfCurrentPage').val(0);

    SearchPArticle();

    $("#btnEdit").click(function () {

        $("#frmSearchPArticle").attr("action", "/master/p-article/get-by-id");

        $("#frmSearchPArticle").attr("method", "POST");

        $("#frmSearchPArticle").submit();
    });



    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);
        SearchPArticle();
    });
});