<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="info_expensetype.aspx.cs" Inherits="salesmanager.pages.info_expensetype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h4 class="page-header">Expense Management</h4>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <b>Expense Type</b>
                            <asp:LinkButton ID="btnaddnew" runat="server" Text="Add New" CssClass="btn btn-default" PostBackUrl="~/pages/en_expensetype.aspx"></asp:LinkButton>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:DataGrid ID="dgexpensetypeInfo" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="false"
                                    Width="100%" BorderStyle="None" CellPadding="0" GridLines="None" AllowSorting="True"
                                    CssClass="table table-bordered table-striped" OnItemCommand="dgexpensetypeInfo_ItemCommand"
                                    OnPageIndexChanged="dgexpensetypeInfo_PageIndexChanged">
                                    <HeaderStyle VerticalAlign="Top" HorizontalAlign="Center" Font-Bold="true" CssClass="sorting_asc" />
                                    <PagerStyle CssClass="gridpager" Mode="NumericPages" />
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="S/No." Visible="true">
                                            <ItemTemplate>
                                                <%# Container.DataSetIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Expense Type" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("expensetypename")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="85%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <a href="en_expensetype.aspx?cId=<%# Eval("expensetypeId") %>" title="Edit" class="btn btn-primary btn-xs">Edit</a>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandName="delete" AlternateText="Delete"
                                                    ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete?');" CssClass="btn btn-primary btn-xs"
                                                    CommandArgument='<%# Eval("expensetypeId") %>' />
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
