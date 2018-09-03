<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="rp_sale.aspx.cs" Inherits="salesmanager.pages.rp_sale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script lang="javascript" type="text/javascript">
        function currentDate1(sender, args) {
            var d = new Date(); //Today
            d.setDate(d.getDate()); //2 years ago
            $find("myDate1").set_selectedDate(d);
        }
        function currentDate2(sender, args) {
            var d = new Date(); //Today
            d.setDate(d.getDate()); //2 years ago
            $find("myDate2").set_selectedDate(d);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h4 class="page-header">Reports Management</h4>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <b>Sale</b>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table">
                                    <tr>
                                        <td style="width: 15%;">Branch</td>
                                        <td style="width: 35%;">
                                            <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%;">User</td>
                                        <td style="width: 35%;">
                                            <asp:DropDownList ID="ddluser" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Date From</td>
                                        <td>
                                            <asp:TextBox ID="txtdatefrom" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender8" BehaviorID="myDate1" runat="server"
                                                Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomLeft" PopupButtonID="txtdatefrom"
                                                OnClientShowing="currentDate1" TargetControlID="txtdatefrom">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>Date To</td>
                                        <td>
                                            <asp:TextBox ID="txtdateto" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="myDate2" runat="server"
                                                Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomLeft" PopupButtonID="txtdateto"
                                                OnClientShowing="currentDate2" TargetControlID="txtdateto">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">
                                            <asp:Button ID="btnexpexcel" runat="server" Text="Export In Excel" CssClass="btn btn-default" OnClick="btnexpexcel_Click" />
                                            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-default" CausesValidation="false" OnClick="btncancel_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:DataGrid ID="dgsaleInfo" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="false"
                                                Width="100%" BorderStyle="None" CellPadding="0" GridLines="None" AllowSorting="True"
                                                CssClass="table table-bordered table-striped"
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
                                                    <asp:TemplateColumn HeaderText="Date" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("regdate")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Branch" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("branchname")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="User" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("name")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Category" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("categoryname")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Product" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("productname")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Qty" Visible="true">
                                                        <ItemTemplate>
                                                            <%# Eval("saleqty")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        <HeaderStyle HorizontalAlign="Left" />
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
