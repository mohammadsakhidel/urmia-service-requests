<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RouteSuggestion.ascx.cs" Inherits="Views_Shared_RouteSuggestion" %>

<%@ Register Src="~/Views/Shared/SuggestionInfo.ascx" TagPrefix="uc" TagName="SuggestionInfo" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:HiddenField ID="hid_Suggestion" runat="server" />

<div class="subject" style="margin-top : 10px;">

    هدایت به سازمان جدید

</div>

<table border="0" cellpadding="2" cellspacing="0" style="margin-top : 10px;">
    <tr>
        <td>
            سازمان :
        </td>
        <td>
            <asp:DropDownList ID="cmb_Organizations" runat="server" CssClass="combobox" Width="200px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="cmb_Organizations"></asp:RequiredFieldValidator>
        </td>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" class="center">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_add" onclick="LinkButton1_Click"></asp:LinkButton>
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
        </td>
    </tr>
</table>

<div style="margin-top : 10px;">

    <asp:UpdatePanel ID="up_Info" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <uc:SuggestionInfo runat="server" ID="uc_SuggestionInfo"/>
        </ContentTemplate>
    </asp:UpdatePanel>

</div>

