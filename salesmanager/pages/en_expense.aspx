<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="en_expense.aspx.cs" Inherits="salesmanager.pages.en_expense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script lang="javascript" type="text/javascript">
        function currentDate1(sender, args) {
            var d = new Date(); //Today
            d.setDate(d.getDate()); //2 years ago
            $find("myDate1").set_selectedDate(d);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
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
                        Stock In
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table class="table">
                                <tr>
                                    <td style="width: 15%;">User</td>
                                    <td style="width: 35%;">
                                        <asp:DropDownList ID="ddluser" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddluser_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* User" Display="Dynamic"
                                            ControlToValidate="ddluser" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator></td>
                                    <td style="width: 15%;">Branch</td>
                                    <td style="width: 35%;">
                                        <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Branch Name" Display="Dynamic"
                                            ControlToValidate="ddlbranch" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td>Manifest</td>
                                    <td>
                                        <asp:DropDownList ID="ddlmanifest" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Manifest" Display="Dynamic"
                                            ControlToValidate="ddlmanifest" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator></td>
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
                                                    Width="50%" BorderStyle="None" CellPadding="0" GridLines="None" AllowSorting="True"
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
                                                        <asp:TemplateColumn HeaderText="Expense Type" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlexpensetype" runat="server" Width="90%">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Amount" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtexpamount" runat="server" Width="90%">
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
