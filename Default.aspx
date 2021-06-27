<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/WebInterface.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="row">
        <div class="col-sm-5">
            <h2 class="home-col-title">سامانه 137 چیست؟</h2>
            <div class="home-col-content">
                سامانه ارتباط مردمی شهرداری ارومیه با هدف برقراری ارتباط مستقیم بین مردم
                    و مسئولین مدیریت شهری راه اندازی شده است. در این سامانه مردم از طریق یکی از
                    دو روش ارسال پیامک به شماره 1000441137 و یا ثبت از طریق همین صفحه درخواست خود
                    را به سامانه ارسال کرده و کد رهگیری دریافت می کنند. پس از ثبت درخواست و رسیدن
                    به دست کاربر مرتبط با موضوع، پیگیری لازم صورت گرفته و نتیجه در سیستم ثبت و از طریق پیامک به
                    اطلاع شهروند خواهد رسید. همچنین شهروند می تواند در هر لحظه با ارسال کد رهگیری
                    دریافت شده به شماره 1000441137 از وضعیت درخواست خود آگاهی پیدا کند.
            </div>
        </div>
        <div class="col-sm-7">
            <h2 class="home-col-title">ثبت درخواست، پیشنهاد، انتقاد و ...</h2>
            <form id="form1" runat="server" style="margin-top: 20px;">
                <div class="form-group">
                    <asp:TextBox ID="tb_Name" runat="server" class="form-control" placeholder="نام و نام خانوادگی"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="tb_MobNumber" runat="server" CssClass="form-control" placeholder="شماره همراه"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="tb_RequestText" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="شرح درخواست" Height="120px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:DropDownList ID="cmb_Organ" runat="server" CssClass="form-control" placeholder="ss"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Button ID="Button1" runat="server" Text="ارسال" CssClass="btn btn-default"
                        Style="min-width: 80px; float: right;" OnClick="Button1_Click" />
                    <div style="clear: both; padding-top: 12px;">
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
    </div>
</asp:Content>

