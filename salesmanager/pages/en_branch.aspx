﻿<%@ Page Title="" Language="C#" MasterPageFile="~/sales.Master" AutoEventWireup="true" CodeBehind="en_branch.aspx.cs" Inherits="salesmanager.pages.en_branch" %>

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
                        Branch
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Branch Name</label>
                                    <asp:TextBox ID="txtbranchname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvbranchname" runat="server" ErrorMessage="* Branch Name" Display="Dynamic"
                                        ControlToValidate="txtbranchname" CssClass="star"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnsave_Click" />
                                <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-default" CausesValidation="false" OnClick="btncancel_Click" />
                                <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
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

    </div>
</asp:Content>
