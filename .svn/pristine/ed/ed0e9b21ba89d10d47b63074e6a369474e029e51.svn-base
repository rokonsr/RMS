<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CustomerAmountReceived.aspx.cs" Inherits="RMS.UI.SaleUI.CustomerAmountReceived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  <script>
      $(document).ready(function () {
      $('[id$=btnReceive]').prop("disabled", true);
      $("#txtCustomerNameForInvoice").autocomplete({
        source: function (request,response) {

            $.ajax({
                type : "POST",
                url: "../WebServices/AutoCompleteService.asmx/GetSpecifiedSalesCustomer",
                contentType: "application/json;charset=uft-8",
                data: "{'customerUsername':'" + $("#txtCustomerNameForInvoice").val() + "'}",
                dataType: "Json",
                success: function (data) {

                    response(data.d);
                },
                error: onError


            });

        }
      });


      $("#smtFetchInvoice").click(
           function () {
              
               var customerIdWithName = $("#txtCustomerNameForInvoice").val(); 
               var customerId = customerIdWithName.split('*****')[1];
               $.ajax({

                   type: "POST",
                   url: "../WebServices/AutoCompleteService.asmx/GetDeservedInvoiceNumber",
                   contentType: "application/Json; charset=uft-8",
                   data: "{'customerId':'" + customerId + "'}",
                   dataType: "Json",
                   success: bindCheckBoxList,
                   error: onError

               });

              
           });

      $("#btnReceive").click(
         function () {
             
             var receivingAmount = $('[id$=txtReceivingAmountForInvoice]').val();
             var collectionSalesId = '';
             var tempSalesId = '';
             var tempSalesIdValue = '';
             var customerId = '';
             var chkBoxCheckedValue = $('[id$=chkBoxListInvoice] input:Checked');
             $(chkBoxCheckedValue).each(function () {
                 tempSalesId = '';
                 tempSalesIdValue = '';
                 tempSalesId = $(this).closest('td').find('label').html();
                 if (tempSalesId !== '' && tempSalesId !== null && tempSalesId !== undefined) {
                     tempSalesIdValue = tempSalesId.split('*****')[4];
                     customerId = tempSalesId.split('*****')[5];
                     collectionSalesId += tempSalesIdValue + '*****';
                 }
             });
             collectionSalesId = collectionSalesId.substr(0, collectionSalesId.length - 5);
             $.ajax({
                 type: "POST",
                 url: "../WebServices/AutoCompleteService.asmx/CutomerRecivingAmountAgainestInvoice",
                 contentType: "application/json; charset=uft-8",
                 data: "{'customerId':'" + customerId + "','collectionSalesId':'" + collectionSalesId + "','receivingAmount':'" + receivingAmount + "'}",
                 dataType: "json",
                 success: function (data) {     
                     var items = data.d;
                     $(items).each(function ()
                     {

                         alert(this);

                     });

                 },
                 error: onError
                
             });


             var counter = 0;
             $('[id$=chkBoxListInvoice] tr').remove();
             $('[id$=chkBoxListInvoice]').append($('<tr></tr>').append($('<td></td>').append($('<input>').attr({
                 type: 'checkbox', name: 'chklistitem',
                 value: this.Value, id: 'chklistitem' + counter
             })).append(
              $('<label>').attr({
                  for: 'chklistitem' + counter++
              }).text('waiting for Invoice Number'))));

             $('[id$=btnReceive]').prop("disabled", true);





         });




      function bindCheckBoxList(result) {
          var items = result.d;
          var counter = 0;

          $('[id$=chkBoxListInvoice] tr').remove();
          $.each(items, function (singleItem) {

              $('[id$=chkBoxListInvoice]').append($('<tr></tr>').append($('<td></td>').append($('<input>').attr({
                  type: 'checkbox', name: 'chklistitem',
                  value: this.Value, id: 'chklistitem' + counter
              })).append(
              $('<label>').attr({
                  for: 'chklistitem' + counter++
              }).text(this))));


          });

          if (items.length > 0) {

              $('[id$=btnReceive]').prop("disabled", false);

          }


      }

    function onError(xhr, errorType, exception) {
        var responseText;
        $("#errorWriringDiv").html("");
        try {
            responseText = jQuery.parseJSON(xhr.responseText);
            $("#errorWriringDiv").append("<div><b>" + responseText.errorType + " + exception </b></div>");
            $("#errorWriringDiv").append("<div><u>Exception</u>:<br/><br />" + responseText.ExceptionType + "</div>");
            $("#errorWriringDiv").append("<div><u>StackTrace</u>:<br/><br />" + responseText.StackTrace + "</div>");
            $("#errorWriringDiv").append("<div><u>Message</u>:<br/><br />" + responseText.Message + "</div>");
        } catch (e) {
            responseText = xhr.responseText;
            $("#errorWriringDiv").html(responseText);
        }
    }


  } );
  </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel runat="server" ID="pnlCode" style="margin-bottom: 10px; text-align: center;">
          <div class="input-validation"></div>
        <table>
            <tr>
                <td>
                    <label style="width: 50px;">Name</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerNameForInvoice" runat="server" ClientIDMode="Static"></asp:TextBox>
                    
                    

                </td>

                <td >
                    
                    <input id="smtFetchInvoice" type="button" value="Load Invoice" style="align-content:flex-start " />
                
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Receive Amount : </td>
                <td>
                    <div class = "input-group">
                        
                
                           <asp:TextBox ID="txtReceivingAmountForInvoice" runat="server" ClientIDMode="Static"></asp:TextBox>

                        </div>
                </td>
                <td>
                     <input id="btnReceive" type="button" value="Click to Receive"   /> </td>
                <td>
                     <div class = "input-group">
                        
                      </div>
                    
               
             
                
            </tr>
        <tr>
                <td>
                   
                </td>
                <td>
                    
                    
             
                    
                    
                </td>

                <td>
                    
                   
                
                    <asp:CheckBoxList ID="chkBoxListInvoice" runat="server" >
                        <asp:ListItem Text="waiting for Invoice Number" Value="0">
                        </asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                     &nbsp;</td>
                <td>
                    <div class = "input-group">
                        
            
                          

                      </div>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                     <div class = "input-group">
                      </div>
                    
               
                </td>
            
            
                
            </tr>
            
            
                <tr>
                <td>
                   
                </td>
                <td>
                    
                    
                   
                    
                    
                </td>

                <td>
                    
                   
                
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <div class = "input-group">
                        
            
                      </div>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                     <div class = "input-group">
                         &nbsp;</div>
                    
               
                </td>
                    
                    
                
                
            </tr>
        </table>
    </asp:Panel>
    
    
     <div  id="errorWriringDiv">



        



    </div>
    
    
     <br />
         <br />
         <br />
         <br />
         
         <br />
   
    
    
        
</asp:Content>
