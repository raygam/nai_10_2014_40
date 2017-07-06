<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phoneTheatreDetail.aspx.vb" Inherits="Main_phoneTheatreDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT" Text=""></asp:Label>
    <br />

    <table width="100%" border="0" align="center">
        <tr>
            <td width="50%" align="center" valign="top">

                <table width="100%" border="0" align="center">
                    <tr><td width="50%"></td><td></td></tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" CssClass="DATA_LABEL" 
                                Text="Theatre :"></asp:Label> 
                        </td>
                        <td>
                            <asp:Label ID="lblTheatreName" runat="server" CssClass="DATA"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" CssClass="DATA_LABEL" 
                                Text="Theatre # :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTheatreNumber" runat="server" CssClass="DATA"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" CssClass="DATA_LABEL" 
                                Text="Mailing Address :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtAddress1" runat="server" Width="190px" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtAddress2" runat="server" Width="190px" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <asp:Label ID="Label5" runat="server" CssClass="DATA_LABEL" 
                                Text="City :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server" Width="165px" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" CssClass="DATA_LABEL" 
                                Text="State :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtState" runat="server" Width="165px" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" CssClass="DATA_LABEL" 
                                Text="Postal Code :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPostal" runat="server" CssClass="DATA" Width="165px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" CssClass="DATA_LABEL" 
                                Text="Phone :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" Width="165px" CssClass="DATA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="DATA_LABEL" 
                                Text="Speed Dial :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtSpeedDial" runat="server" CssClass="DATA" Width="165px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" CssClass="DATA_LABEL" 
                                Text="Public Phone :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPublicPhone" runat="server" CssClass="DATA" Width="165px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" CssClass="DATA_LABEL" 
                                Text="Fax Phone :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtFax" runat="server" CssClass="DATA" Width="165px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" CssClass="DATA_LABEL" 
                                Text="Rec Phone :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtRecording" runat="server" CssClass="DATA" Width="165px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" CssClass="DATA_LABEL" 
                                Text="Rec Speed Dial :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtRecordingSpeed" runat="server" CssClass="DATA" 
                                Width="165px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="DATA_LABEL" 
                                Text="Booking :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtBooking" runat="server" CssClass="DATA" Width="165px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" CssClass="DATA_LABEL" 
                                Text="Company :"></asp:Label> 
                        </td>
                        <td>
                            <asp:Label ID="lblCompany" runat="server" CssClass="DATA"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label16" runat="server" CssClass="DATA_LABEL" 
                                Text="EIN Number :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEIN" runat="server" CssClass="DATA"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2"  align="center">
                            <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="BUTTON_TEXT" 
                                Width="100px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="cmdCancel" runat="server" Text="Return" CssClass="BUTTON_TEXT" 
                                Width="100px" />
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>        
                    <tr><td colspan="2" align="center">
                         </td></tr>        
                    <tr><td colspan="2"></td></tr>        
                </table>

                </td>
        
            <td align="center" valign="top">

                <table width="100%" border="0" align="center">
                    <tr><td align="center">
                        <asp:Label ID="Label17" runat="server" Text="Personnel"></asp:Label>
                        </td></tr>        
                    <tr><td>&nbsp;</td></tr>        
                    <tr>
                        <td align="right">
                            <asp:Table ID="tblEmp" runat="server" Width="300px" GridLines="None">
                            </asp:Table>
                        </td>
                    </tr>
                </table>

            </td>

        </tr>

    </table>

    <br />
    <br />

</asp:Content>

