﻿<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="info_sale.aspx.cs" Inherits="salesmanager.pages.info_sale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="container-fluid">
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
                            <b>Sales</b>
                            <asp:LinkButton ID="btnaddnew" runat="server" Text="Add New" CssClass="btn btn-default" PostBackUrl="~/pages/en_sale.aspx" Visible="false"></asp:LinkButton>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table">
                                    <tr>
                                        <td style="width: 15%;">User
                                        </td>
                                        <td style="width: 25%;">
                                            <asp:DropDownList ID="ddlusername" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 15%;">Branch
                                        </td>
                                        <td style="width: 25%;">
                                            <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%;">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Date From
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdatefrom" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server"
                                                Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomLeft" PopupButtonID="txtdatefrom"
                                                TargetControlID="txtdatefrom">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>Date To
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdateto" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                                                Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomLeft" PopupButtonID="txtdateto"
                                                TargetControlID="txtdateto">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-default"
                                                OnClick="btnsearch_Click" />
                                            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-default"
                                                CausesValidation="false" OnClick="btncancel_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <asp:DataGrid ID="dgsaleInfo" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="false"
                                                Width="100%" BorderStyle="None" CellPadding="0" GridLines="None" AllowSorting="True"
                                                CssClass="table table-bordered table-striped" OnItemCommand="dgsaleInfo_ItemCommand"
                                                OnPageIndexChanged="dgsaleInfo_PageIndexChanged">
                                                <HeaderStyle VerticalAlign="Top" HorizontalAlign="Center" Font-Bold="true" CssClass="sorting_asc" />
                                                <PagerStyle CssClass="gridpager" Mode="NumericPages" />
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="S/No." Visible="true">
                                                        <ItemTemplate>
                                                            <%# Container.DataSetIndex + 1 %>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="CML No." Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("cmlNo")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Assign Job Date" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("regdate", "{0:dd/MM/yyyy}") %>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Branch" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("branchname")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="User" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("name")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                                        <ItemTemplate>
                                                            <a href="en_sale.aspx?ajId=<%# Eval("assignjobId") %>" title="Add Sale" class="btn btn-primary btn-xs">Sale</a>
                                                            <a href="info_soldItem.aspx?ajId=<%# Eval("assignjobId") %>" title="Edit" class="btn btn-primary btn-xs">Sold</a>
                                                            <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandName="delete" AlternateText="Delete"
                                                                ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete?');" CssClass="btn btn-primary btn-xs"
                                                                CommandArgument='<%# Eval("saleId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="20%" />
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
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
            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
</asp:Content>
