<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="info_user.aspx.cs" Inherits="salesmanager.pages.info_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h4 class="page-header">User Management</h4>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <b>User Account</b>
                            <asp:LinkButton ID="btnaddnew" runat="server" Text="Add New" CssClass="btn btn-default" PostBackUrl="~/pages/en_user.aspx"></asp:LinkButton>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:DataGrid ID="dguserInfo" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="false"
                                    Width="100%" BorderStyle="None" CellPadding="0" GridLines="None" AllowSorting="True"
                                    CssClass="table table-bordered table-striped" OnItemCommand="dguserInfo_ItemCommand"
                                    OnPageIndexChanged="dguserInfo_PageIndexChanged">
                                    <HeaderStyle VerticalAlign="Top" HorizontalAlign="Center" Font-Bold="true" CssClass="sorting_asc" />
                                    <PagerStyle CssClass="gridpager" Mode="NumericPages" />
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="S/No." Visible="true">
                                            <ItemTemplate>
                                                <%# Container.DataSetIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Name" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("name")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Mobile No." Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("mobileno")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Email" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("email")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Address" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("address")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Branch" Visible="true">
                                            <ItemTemplate>
                                                <%# Eval("branchname")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <a href="en_user.aspx?uId=<%# Eval("userId") %>" title="Edit" class="btn btn-primary btn-xs">Edit</a>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandName="delete" AlternateText="Delete"
                                                    ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete?');" CssClass="btn btn-primary btn-xs"
                                                    CommandArgument='<%# Eval("userId") %>' />
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
