<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Task01.MobileSearch.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile Search</title>
    <script src="https://code.jquery.com/jquery-2.2.0.min.js" type="text/javascript"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <div class="row text-center">
                <h2>Welcome to car Search</h2>
                <div class="row form-horizontal">
                    <div class="col-md-6 col-md-offset-3">
                        <fieldset>
                            <div class="form-group">
                                <label for="CarProducer" class="col-md-3 control-label">Car Producer</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="CarProducer" runat="server" CssClass="form-control select" SelectMethod="GetProducers" AutoPostBack="true" OnSelectedIndexChanged="CarProducer_SelectedIndexChanged" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="CarModel" class="col-md-3 control-label">Car Model</label>
                                <div class="col-md-9">
                                    <asp:DropDownList runat="server" ID="CarModel" CssClass="form-control select" />
                                </div>
                            </div>
                            <div class="form-group text-left">
                                <label for="Extras" class="col-md-3 control-label">Extras</label>
                                <div class="col-md-9">
                                    <div>
                                        <asp:CheckBoxList ID="Extras" runat="server" SelectMethod="GetExtras"
                                            RepeatColumns="1"
                                            RepeatLayout="Flow"
                                            TextAlign="Right"
                                            EnableTheming="True">
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="Engine" class="col-md-3 control-label">Engine Types</label>
                                <div class="col-md-9">
                                    <asp:RadioButtonList runat="server" ID="Engine" RepeatDirection="Horizontal" SelectMethod="GetEngines"></asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-9 col-lg-offset-3 pull-right">
                                    <asp:Button runat="server" ID="SubmitBtn" Text="Get That Car" OnClick="SubmitBtn_Click" CssClass="btn btn-info full-width" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
        <div class="jumbotron text-center">
            <h4>Your choice :</h4>
            <asp:Literal ID="Result" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
