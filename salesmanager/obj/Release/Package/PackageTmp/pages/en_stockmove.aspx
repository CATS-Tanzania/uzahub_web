<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="en_stockmove.aspx.cs" Inherits="salesmanager.pages.en_stockmove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script lang="javascript" type="text/javascript">
        function currentDate1(sender, args) {
            var d = new Date(); //Today
            d.setDate(d.getDate()); //2 years ago
            $find("myDate1").set_selectedDate(d);
        }
        var _Popc = false;
        function popupcategory(id) {
            if (_Popc && !_Popc.closed) {
                _Popc.focus();
            }
            else {
                var width = 500;
                var height = 350;
                var left = (screen.width - width) / 2;
                var top = (screen.height - height) / 2;
                var params = 'width=' + width + ', height=' + height;
                params += ', top=' + top + ', left=' + left;
                params += ', directories=no';
                params += ', location=no';
                params += ', menubar=no';
                params += ', resizable=no';
                params += ', scrollbars=no';
                params += ', status=no';
                params += ', toolbar=no';
                _Popc = window.open("fly_category.aspx", "category", params);
                _Popc.focus();
            }
            return false;
        }
        function categoryLoad() {
            document.getElementById("<%=btnloadcategory.ClientID  %>").click();
        }
        var _Popi = false;
        function popupitem(id) {
            if (_Popi && !_Popi.closed) {
                _Popi.focus();
            }
            else {
                var width = 550;
                var height = 500;
                var left = (screen.width - width) / 2;
                var top = (screen.height - height) / 2;
                var params = 'width=' + width + ', height=' + height;
                params += ', top=' + top + ', left=' + left;
                params += ', directories=no';
                params += ', location=no';
                params += ', menubar=no';
                params += ', resizable=no';
                params += ', scrollbars=no';
                params += ', status=no';
                params += ', toolbar=no';
                _Popi = window.open("fly_item.aspx", "item", params);
                _Popi.focus();
            }
            return false;
        }
        function itemLoad() {
            document.getElementById("<%=btnloadItem.ClientID  %>").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">Product Management</h4>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Stock Movement
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table class="table">
                                <tr>
                                    <td style="width: 15%;">Source Branch</td>
                                    <td style="width: 35%;">
                                        <asp:DropDownList ID="ddlsrcbranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Source Branch" Display="Dynamic"
                                            ControlToValidate="ddlsrcbranch" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator></td>
                                    <td style="width: 15%;">Destination Branch</td>
                                    <td style="width: 35%;">
                                        <asp:DropDownList ID="ddldesbranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Destination Branch" Display="Dynamic"
                                            ControlToValidate="ddldesbranch" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td>User</td>
                                    <td>
                                        <asp:DropDownList ID="ddluser" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* User" Display="Dynamic"
                                            ControlToValidate="ddluser" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator></td>
                                    <td>Date</td>
                                    <td>
                                        <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender8" BehaviorID="myDate1" runat="server"
                                            Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomLeft" PopupButtonID="txtdate"
                                            OnClientShowing="currentDate1" TargetControlID="txtdate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DataGrid ID="dgproductInfo" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                                    Width="100%" BorderStyle="None" CellPadding="0" GridLines="None" AllowSorting="True"
                                                    CssClass="table table-bordered table-striped" OnItemDataBound="dginvoice_ItemDataBound">
                                                    <HeaderStyle VerticalAlign="Top" HorizontalAlign="Center" Font-Bold="true" CssClass="sorting_asc" />
                                                    <PagerStyle CssClass="gridpager" Mode="NumericPages" />
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="SN" Visible="true">
                                                            <ItemTemplate>
                                                                <%# Container.DataSetIndex + 1 %>
                                                                <asp:HiddenField ID="hdIdd" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Category" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlcategory" runat="server" Width="90%" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:ImageButton ID="imgbtncategory" runat="server" ImageUrl="../img/pluse.png" ToolTip="Add more category"
                                                                    CausesValidation="false" OnClientClick="popupcategory();" />
                                                                <asp:HiddenField ID="hdcategoryId" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Item" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlproduct" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:ImageButton ID="imgbtnproduct" runat="server" ImageUrl="../img/pluse.png" CausesValidation="false"
                                                                    ToolTip="Add more product" OnClientClick="popupitem();" />
                                                                <asp:HiddenField ID="hditemId" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Avl. Qty." Visible="true">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtavlqty" runat="server" Width="98%" ReadOnly="true">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Quantity" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtqty" runat="server" Width="98%" AutoPostBack="true" OnTextChanged="txtqty_OnTextChanged">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Unit Price" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtunitprice" runat="server" Width="90%" AutoPostBack="true" OnTextChanged="txtqty_OnTextChanged">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Total Amount" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txttotalAmount" runat="server" Width="90%">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnsave_Click" />
                                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-default" CausesValidation="false" OnClick="btncancel_Click" />
                                        <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>

                                        <asp:Button ID="btnloadcategory" runat="server" Text="" Style="display: none;" OnClick="btnloadcategory_Click"
                                            CausesValidation="false" />
                                        <asp:Button ID="btnloadItem" runat="server" Text="" Style="display: none;" OnClick="btnloadItem_Click"
                                            CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /#page-wrapper -->

    </div>
</asp:Content>
