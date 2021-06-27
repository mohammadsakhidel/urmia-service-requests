<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/WebInterface.master" AutoEventWireup="true" CodeFile="Tracking.aspx.cs" Inherits="Tracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">

    <div class="home-page-title">
        <h2>پیگیری درخواست</h2>
    </div>
    <div class="home-page-content">
        لطفاً از طریق فرم زیر کد رهگیری درخواست خود را وارد نموده و ارسال کنید (کد رهگیری به کوچک و بزرگ بودن حروف حساس نیست).
    </div>

    <div style="margin: 15px 0; max-width: 450px;">
        <form runat="server" id="form2">
            <div class="form-group">
                <input runat="server" id="tb_TrackingCode" type="text" class="form-control" placeholder="کد رهگیری درخواست" />
            </div>
            <div class="form-group">
                <asp:Button ID="btn_SendTrackingCode" runat="server" Text="ارسال" CssClass="btn btn-default" style="width: 80px;" OnClick="btn_SendTrackingCode_Click"  />
                <div style="padding-top: 12px;">
                        <span class="text-danger">
                            <asp:Literal ID="lblErrorMessage" runat="server" Text="" Visible="false" Mode="PassThrough"></asp:Literal>
                        </span>
                        <span class="text-success">
                            <asp:Literal ID="lblSuccessMessage" runat="server" Text="" Visible="false" Mode="PassThrough"></asp:Literal>
                        </span>
                    </div>
            </div>
        </form>
    </div>

</asp:Content>

