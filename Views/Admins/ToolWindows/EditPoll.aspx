<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="EditPoll.aspx.cs" Inherits="Views_Admins_ToolWindows_NewPoll" %>

<%@ Register Src="~/Views/Shared/PollEditor.ascx" TagPrefix="uc" TagName="Poll" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">
    
    <uc:PageTitle runat="server" Text="ویرایش نظرسنجی"/>

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div style="margin : 10px 30px 10px 0;">
        <uc:Poll runat="server" ID="uc_Poll"/>
    </div>

    <table border="0" cellpadding="0" cellspacing="0" class="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" 
                            ValidationGroup="fillform" onclick="LinkButton1_Click"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="loading_container">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up_save">
                    <ProgressTemplate>
                        <div class="loading"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>

</asp:Content>

