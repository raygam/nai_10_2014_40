<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phoneEmpDetail.aspx.vb" Inherits="Main_phoneEmpDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT" Text=""></asp:Label>
    <br />

    <table width="90%" border="0" align="center">
        <tr><td width="40%"></td><td>
            <asp:Label ID="lblID" runat="server" CssClass="DATA" Visible="False"></asp:Label>
            <asp:Label ID="lblActive" runat="server" CssClass="DATA" Visible="False"></asp:Label>
            </td></tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" CssClass="DATA_LABEL" 
                    Text="First Name :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFirst" runat="server" Width="234px" CssClass="DATA"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" CssClass="DATA_LABEL" 
                    Text="Last Name :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtLast" runat="server" Width="234px" CssClass="DATA"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                <asp:Label ID="Label5" runat="server" CssClass="DATA_LABEL" 
                    Text="Location :"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="DATA" Width="225px"> 
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label6" runat="server" CssClass="DATA_LABEL" 
                    Text="Job Class :"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlJobClass" runat="server" CssClass="DATA" Width="225px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label7" runat="server" CssClass="DATA_LABEL" 
                    Text="Network Login / Alias :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtAlias" runat="server" CssClass="DATA"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" runat="server" CssClass="DATA_LABEL" 
                    Text="Email Address :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="234px" CssClass="DATA"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label19" runat="server" CssClass="DATA_LABEL" 
                    Text="Title :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="234px" CssClass="DATA"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />

    <table width="90%" border="0" align="center">
        <tr>
            <td width="50%" align="center">
                            <asp:Label ID="Label21" runat="server" CssClass="DATA_LABEL" 
                    Text="Office Information"></asp:Label>
                        </td><td align="center">
                            <asp:Label ID="Label22" runat="server" CssClass="DATA_LABEL" 
                    Text="Home Information"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <table width="100%" border="0" align="center">
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="DATA_LABEL" Text="Address :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficeAdd1" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txtOfficeAdd2" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label2" runat="server" CssClass="DATA_LABEL" Text="City : "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficeCity" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label4" runat="server" CssClass="DATA_LABEL" Text="State :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficeState" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label10" runat="server" CssClass="DATA_LABEL" Text="Postal :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficePostal" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label11" runat="server" CssClass="DATA_LABEL" Text="Phone :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficePhone" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label23" runat="server" CssClass="DATA_LABEL" Text="Extension :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficeExt" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label12" runat="server" CssClass="DATA_LABEL" 
                                Text="Speed Dial :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficeSD" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label13" runat="server" CssClass="DATA_LABEL" Text="Fax :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficeFax" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" valign="top">
                <table width="100%" border="0" align="center">
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="DATA_LABEL" Text="Address :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHomeAddress1" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txtHomeAddress2" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label15" runat="server" CssClass="DATA_LABEL" Text="City : "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHomeCity" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label16" runat="server" CssClass="DATA_LABEL" Text="State :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHomeState" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label17" runat="server" CssClass="DATA_LABEL" Text="Postal :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHomePostal" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label18" runat="server" CssClass="DATA_LABEL" Text="Phone :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHomePhone" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="Label20" runat="server" CssClass="DATA_LABEL" Text="Mobile :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>            
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>             
        <tr>
            <td align="right">
                <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="BUTTON_TEXT" 
                    Width="100px" />&nbsp;&nbsp;&nbsp;
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdCancel" runat="server" Text="Return" CssClass="BUTTON_TEXT" 
                    Width="100px" />
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>             
    </table>
    <br />
    <br />

</asp:Content>

