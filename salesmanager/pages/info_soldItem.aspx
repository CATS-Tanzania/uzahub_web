<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="info_soldItem.aspx.cs" Inherits="salesmanager.pages.info_soldItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">Sales Management</h4>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Sales
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table class="table">
                                <tr>
                                    <td colspan="4">
                                        <asp:DataGrid ID="dgproductInfo" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                            Width="100%" BorderStyle="None" CellPadding="0" GridLines="None" AllowSorting="True"
                                            CssClass="table table-bordered table-striped" OnItemDataBound="dgproductInfo_ItemDataBound">
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
                                                <asp:TemplateColumn HeaderText="Customer Name" Visible="true">
                                                    <ItemTemplate>
                                                        <%# Eval("cusname")%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Description Of Goods For Delivery" Visible="true">
                                                    <ItemTemplate>
                                                        <%# Eval("productname")%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Quantity" Visible="true">
                                                    <ItemTemplate>
                                                        <%# Eval("saleqty")%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Measurement(Kg)" Visible="true">
                                                    <ItemTemplate>
                                                        <%# Eval("measurementQty")%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Sold Date" Visible="true">
                                                    <ItemTemplate>
                                                        <%# Eval("regdate")%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-default" CausesValidation="false" OnClick="btncancel_Click" />
                                        <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
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
