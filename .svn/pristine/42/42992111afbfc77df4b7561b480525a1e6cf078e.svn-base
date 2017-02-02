//Search Username

$(function () {
    



    $('#txtCreateUserName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchUserInfo",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    $('#txtDesignationSearch').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchDesignation",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    $('#txtRoleName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchRole",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });


    $('#txtSupplierName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchSupplierName",
                data: "{'supplierName': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    $('#txtCategoryName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchCategory",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });
   // Enamul
    $('#txtMeasurementName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchMeasurement",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });
    //Enamul
    $('#txtBrandName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchBrand",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });
    
    $('#txtFoodScheduleName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchFoodScheduleName",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    $('#txtProductName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchProductName",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    //Enamul
    $('#txtRegionName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchRegionName",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });
    //Enamul
    $('#txtProductCode').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchProductCode",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });
    //jQuery('#txtProductCode').on("invalid", function (event) {
    //    //this.setCustomValidity('Invalid product code!');
    //});

    //Ataur
    // Search Customer Username 
    $('#txtCustomerUsername').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchCustomerusename",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    //Ataur
    // Search Customer Username For Sale Report Generation
    $('#txtCustomerUsername').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../UI/WebServices/AutoCompleteService.asmx/SearchCustomerusename",
                data: "{'searchText': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });



    // Rokon
    // Search Invoice Number
    $('#txtInvoiceNumber').autocomplete({
        source: function (request, response) {
            //var supplier = $('#ddlSupplierList').val();
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchInvoiceNumber",
                data: "{'searchText': '" + request.term + "' }",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    // Rokon
    // Search Invoice Number For Report Generation
    $('#txtInvoiceNumber').autocomplete({
        source: function (request, response) {
            //var supplier = $('#ddlSupplierList').val();
            $.ajax({
                url: "../../UI/WebServices/AutoCompleteService.asmx/SearchInvoiceNumber",
                data: "{'searchText': '" + request.term + "' }",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    // Rokon
    // Search Product Number
    $('#txtReturnProductCode').autocomplete({
        source: function (request, response) {
            var invoice = $('#txtInvoiceNumber').val();
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchProductId",
                data: "{'productId': '" + request.term + "', 'invoiceNumber': '" + invoice + "' }",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    // Rokon
    // Search Product Name
    $('#txtReturnProductName').autocomplete({
        source: function (request, response) {
            var invoice = $('#txtInvoiceNumber').val();
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchProduct",
                data: "{'productname': '" + request.term + "', 'invoiceNumber': '" + invoice + "' }",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });
   
    //Ataur
    //Search Sale Ledger Invoice Number
    $('#txtSaleLedgerInvoiceNumber').autocomplete({
        source: function (request, response) {          
            $.ajax({
                url: "../WebServices/AutoCompleteService.asmx/SearchSaleLedgerInvoiceNumber",
                data: "{'searchText': '" + request.term + "' }",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });

    //Ataur
    //Search Invoice Number For Sale Report Generate
    $('#txtSaleLedgerInvoiceNumber').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../UI/WebServices/AutoCompleteService.asmx/SearchSaleLedgerInvoiceNumber",
                data: "{'searchText': '" + request.term + "' }",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });


});