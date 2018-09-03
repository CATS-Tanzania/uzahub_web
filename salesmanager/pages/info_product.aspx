<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="info_product.aspx.cs" Inherits="salesmanager.pages.info_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="container-fluid">
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
                            <b>Product</b>
                            <asp:LinkButton ID="btnaddnew" runat="server" Text="Add New" CssClass="btn btn-default" PostBackUrl="~/pages/en_product.aspx"></asp:LinkButton>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:DataGrid ID="dgproductInfo" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="false"
                                    Width="100%" BorderStyle="None" CellPadding="0" GridLines="None" AllowSorting="True"
                                    CssClass="table table-bordered table-striped" OnItemCommand="dgproductInfo_ItemCommand"
                                    OnPageIndexChanged="dgproductInfo_PageIndexChanged">
                                    <HeaderStyle VerticalAlign="Top" HorizontalAlign="Center" Font-Bold="true" CssClass="sorting_asc" />
                                    <PagerStyle CssClass="gridpager" Mode="NumericPages" />
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="S/No." Visible="true">
                                            <ItemTemplate>
                                                <%# Container.DataSetIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <%--<asp:TemplateColumn HeaderText="Category Name" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("categoryname")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>--%>
                                        <asp:TemplateColumn HeaderText="Product Name" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("productname")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="55%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Buy Price" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("buyprice")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Sell Price" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("sellprice")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <a href="en_product.aspx?pId=<%# Eval("productId") %>" title="Edit" class="btn btn-primary btn-xs">Edit</a>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandName="delete" AlternateText="Delete"
                                                    ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete?');" CssClass="btn btn-primary btn-xs"
                                                    CommandArgument='<%# Eval("productId") %>' />
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                                <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
                            </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
</asp:Content>
