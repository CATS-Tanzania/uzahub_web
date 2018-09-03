<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="en_assignjob.aspx.cs" Inherits="salesmanager.pages.en_assignjob" %>

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
                <h4 class="page-header">Manifest Management</h4>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Assign Job
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table class="table">
                                <tr>
                                    <td style="width: 13%;">No. CML</td>
                                    <td style="width: 22%;">
                                        <asp:Label ID="lblcmlno" runat="server" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 10%;">Date</td>
                                    <td style="width: 25%;">
                                        <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender8" BehaviorID="myDate1" runat="server"
                                            Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomLeft" PopupButtonID="txtdate"
                                            OnClientShowing="currentDate1" TargetControlID="txtdate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td style="width: 10%;">Branch</td>
                                    <td style="width: 20%;">
                                        <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Branch Name" Display="Dynamic"
                                            ControlToValidate="ddlbranch" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Truck No.</td>
                                    <td>
                                        <asp:TextBox ID="txttruckNo" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Truck No." Display="Dynamic"
                                            ControlToValidate="txttruckNo" CssClass="star"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Driver Name</td>
                                    <td>
                                        <asp:TextBox ID="txtdrivername" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Driver Name" Display="Dynamic"
                                            ControlToValidate="txtdrivername" CssClass="star"></asp:RequiredFieldValidator></td>
                                    <td>License No.</td>
                                    <td>
                                        <asp:TextBox ID="txtdriverlncno" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Driver License No." Display="Dynamic"
                                            ControlToValidate="txtdriverlncno" CssClass="star"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td>Conductor Name</td>
                                    <td>
                                        <asp:TextBox ID="txtconductorname" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Conductor Name" Display="Dynamic"
                                            ControlToValidate="txtconductorname" CssClass="star"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Fuel In(Ltr)</td>
                                    <td>
                                        <asp:DropDownList ID="ddlfuelIn" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Diesel Fueled In DAR" Display="Dynamic"
                                            ControlToValidate="ddlfuelIn" InitialValue="00" CssClass="star"></asp:RequiredFieldValidator></td>
                                    <td>Fuel Out(Ltr)</td>
                                    <td>
                                        <asp:DropDownList ID="ddlfuelOut" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="* Diesel Fueled Out DAR" Display="Dynamic"
                                            ControlToValidate="ddlfuelOut" InitialValue="00" CssClass="star"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="font-weight: bold;">Odometer Reading</td>
                                    <td>User Name</td>
                                    <td>
                                        <asp:DropDownList ID="ddluser" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="* User Name" Display="Dynamic"
                                            ControlToValidate="ddluser" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Arrival At CML</td>
                                    <td>
                                        <asp:TextBox ID="txtomreadingarrival" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="* Arrival At CML" Display="Dynamic"
                                            ControlToValidate="txtomreadingarrival" CssClass="star"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Depart. From CML</td>
                                    <td>
                                        <asp:TextBox ID="txtomreadingdeparture" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="* Departure From CML" Display="Dynamic"
                                            ControlToValidate="txtomreadingdeparture" CssClass="star"></asp:RequiredFieldValidator></td>
                                    <td>Mileage</td>
                                    <td>
                                        <asp:TextBox ID="txtmileage" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="* Mileage" Display="Dynamic"
                                            ControlToValidate="txtmileage" CssClass="star"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td colspan="6">
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
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Description Of Goods For Delivery" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlproduct" runat="server" Width="90%">
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hditemId" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Quantity" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlQty" runat="server" Width="90%">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Measurement" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlmeasurement" runat="server" Width="90%">
                                                                    <asp:ListItem Value="00" Text="- Select -" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="1 Kg"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="2 Kg"></asp:ListItem>
                                                                    <asp:ListItem Value="5" Text="5 Kg"></asp:ListItem>
                                                                    <asp:ListItem Value="25" Text="25 Kg"></asp:ListItem>
                                                                    <asp:ListItem Value="50" Text="50 Kg"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
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
