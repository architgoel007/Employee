<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="Employee.EmployeePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 259px;
        }
        .auto-style2 {            width: 220px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;" border="1">
                <tr>
                    <td class="auto-style1">First Name</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">Last Name</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style1">Department</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlDepartment" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">Gender</td>
                    <td>
                        <asp:RadioButton ID="rdBtnMale" runat="server" GroupName="Gender" Text="Male" />
                        <br />
                        <asp:RadioButton ID="rdBtnFemale" runat="server" GroupName="Gender" Text="Female" />
                    </td>
                </tr>
                <tr>
                     <td>
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="4">
                        <br />
                        <br />
                        <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                <asp:BoundField DataField="Department" HeaderText="Department" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnCommand="btnEdit_Command" CommandArgument='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDel" runat="server" OnCommand="btnDel_Command" Text="Delete" CommandArgument='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                    
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
