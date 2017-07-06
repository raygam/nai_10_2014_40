<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="econtactDetail.aspx.vb" Inherits="Main_econtactDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT" Text=""></asp:Label>
    <br />

    <asp:Table ID="tblEmp" runat="server" CssClass="DATA" GridLines="None" HorizontalAlign="Center" Width="600px">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">
                <asp:Table ID="tblAddress" runat="server">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="Label10" runat="server" Text="Home Address" CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Address:" CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtAddress1" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtAddress2" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label3" runat="server" Text="City:"  CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtCity" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label4" runat="server" Text="State:"  CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtState" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Postal Code:"  CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtPostal" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Home Phone:"  CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtPhone" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <asp:Table ID="tblContact" runat="server">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="Label11" runat="server" Text="Person to Contact" CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label6" runat="server" Text="First Name:" CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtContactFirst" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label7" runat="server" Text="Last Name:"  CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtContactLast" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label8" runat="server" Text="Relationship:"  CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtContactRelation" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label9" runat="server" Text="Phone:"  CssClass="DATA_LABEL"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtContactPhone" runat="server" CssClass="DATA"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblFirst" runat="server" Text=""  CssClass="DATA" Visible="false"></asp:Label>
                            <asp:Label ID="lblLast" runat="server" Text=""  CssClass="DATA" Visible="false"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblEmpId" runat="server" Text=""  CssClass="DATA" Visible="false"></asp:Label>
                            <asp:Label ID="lblContactID" runat="server" Text=""  CssClass="DATA" Visible="false"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <asp:Table ID="tblAuto" runat="server">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="7" HorizontalAlign="Center">
                            <asp:Label ID="Label20" runat="server" Text="Automobile Information"  CssClass="DATA_LABEL"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>                    
                        <asp:TableCell><asp:Label ID="Label12" runat="server" Text="License Plate"  CssClass="DATA"></asp:Label></asp:TableCell>                    
                        <asp:TableCell><asp:Label ID="Label13" runat="server" Text="State"  CssClass="DATA"></asp:Label></asp:TableCell>                    
                        <asp:TableCell><asp:Label ID="Label14" runat="server" Text="Color"  CssClass="DATA"></asp:Label></asp:TableCell>                    
                        <asp:TableCell><asp:Label ID="Label15" runat="server" Text="Make"  CssClass="DATA"></asp:Label></asp:TableCell>                    
                        <asp:TableCell><asp:Label ID="Label16" runat="server" Text="Model"  CssClass="DATA"></asp:Label></asp:TableCell>                    
                        <asp:TableCell><asp:Label ID="Label17" runat="server" Text="Year"  CssClass="DATA"></asp:Label></asp:TableCell>                    
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label18" runat="server" Text="Auto 1:"  CssClass="DATA"></asp:Label></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtPlate1" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtState1" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtColor1" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtMake1" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtModel1" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtYear1" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label19" runat="server" Text="Auto 2:"  CssClass="DATA"></asp:Label></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtPlate2" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtState2" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtColor2" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtMake2" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtModel2" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                        <asp:TableCell><asp:TextBox ID="txtYear2" runat="server" CssClass="DATA" Width="50px"></asp:TextBox></asp:TableCell>                    
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="BUTTON_TEXT" Width="75px" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Button ID="cmdReturn" runat="server" Text="Return" CssClass="BUTTON_TEXT" Width="75px" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />

</asp:Content>

