<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="comp2084_lesson9.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>
    <h5>All the fields are required.</h5>

    <div class="form-group">
        <label for="txtLastName" class="col-sm-2">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" required />
    </div>

    <div class="form-group">
        <label for="txtFirstName" class="col-sm-2">Firs tName:</label>
        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtDate" class="col-sm-2">Enrollment Date:</label>
        <asp:TextBox ID="txtDate" runat="server" type="date" />
        

    </div>
    
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" 
             OnClick="btnSave_Click" />

    </div>
</asp:Content>
