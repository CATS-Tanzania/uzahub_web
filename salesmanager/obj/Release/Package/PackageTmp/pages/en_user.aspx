<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="en_user.aspx.cs" Inherits="salesmanager.pages.en_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
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
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Company Name</label>
                                    <asp:Label ID="lblcompanyname" runat="server" Text="CATS TANZANIA LTD." CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Name" Display="Dynamic"
                                        ControlToValidate="txtname" CssClass="star"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>User Type</label>
                                    <asp:DropDownList ID="ddlusertype" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* User type" Display="Dynamic"
                                        ControlToValidate="ddlusertype" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Mobile No.</label>
                                    <asp:TextBox ID="txtmobileno" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Mobile No." Display="Dynamic"
                                        ControlToValidate="txtmobileno" CssClass="star"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Email" Display="Dynamic"
                                        ControlToValidate="txtemail" CssClass="star"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnsave_Click" />
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-default" CausesValidation="false" OnClick="btncancel_Click" />
                                    <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Username</label>
                                    <asp:TextBox ID="txtusername" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Username" Display="Dynamic"
                                        ControlToValidate="txtusername" CssClass="star"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvpassword" runat="server" ErrorMessage="* Password" Display="Dynamic"
                                        ControlToValidate="txtpassword" CssClass="star"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Branch Name</label>
                                    <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Branch Name" Display="Dynamic"
                                        ControlToValidate="ddlbranch" InitialValue="0" CssClass="star"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <!-- /.row (nested) -->
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
</asp:Content>
