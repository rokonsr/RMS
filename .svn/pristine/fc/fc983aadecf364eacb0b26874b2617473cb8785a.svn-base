
<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateSale.aspx.cs" Inherits="RMS.UI.SaleUI.CreateSale" %>
<%@ MasterType VirtualPath="~/Rms.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .customInvalid {
            color: red;
            border: 1px solid red !important;
            /*box-shadow: 4px 4px 20px rgba(200, 0, 0, 0.85);*/
            background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABYAAAAWCAYAAADEtGw7AAAACXBIWXMAAAsTAAALEwEAmpwYAAA57GlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMwNjcgNzkuMTU3NzQ3LCAyMDE1LzAzLzMwLTIzOjQwOjQyICAgICAgICAiPgogICA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPgogICAgICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIgogICAgICAgICAgICB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iCiAgICAgICAgICAgIHhtbG5zOmRjPSJodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyIKICAgICAgICAgICAgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIgogICAgICAgICAgICB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIKICAgICAgICAgICAgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIKICAgICAgICAgICAgeG1sbnM6dGlmZj0iaHR0cDovL25zLmFkb2JlLmNvbS90aWZmLzEuMC8iCiAgICAgICAgICAgIHhtbG5zOmV4aWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20vZXhpZi8xLjAvIj4KICAgICAgICAgPHhtcDpDcmVhdG9yVG9vbD5BZG9iZSBQaG90b3Nob3AgQ0MgMjAxNSAoV2luZG93cyk8L3htcDpDcmVhdG9yVG9vbD4KICAgICAgICAgPHhtcDpDcmVhdGVEYXRlPjIwMTctMDEtMTJUMTE6MDI6NDQrMDY6MDA8L3htcDpDcmVhdGVEYXRlPgogICAgICAgICA8eG1wOk1vZGlmeURhdGU+MjAxNy0wMS0xMlQxNjoyMjoyMCswNjowMDwveG1wOk1vZGlmeURhdGU+CiAgICAgICAgIDx4bXA6TWV0YWRhdGFEYXRlPjIwMTctMDEtMTJUMTY6MjI6MjArMDY6MDA8L3htcDpNZXRhZGF0YURhdGU+CiAgICAgICAgIDxkYzpmb3JtYXQ+aW1hZ2UvcG5nPC9kYzpmb3JtYXQ+CiAgICAgICAgIDxwaG90b3Nob3A6Q29sb3JNb2RlPjM8L3Bob3Rvc2hvcDpDb2xvck1vZGU+CiAgICAgICAgIDx4bXBNTTpJbnN0YW5jZUlEPnhtcC5paWQ6MWRiYjE0NTMtYWZkMC1hNzQyLTgwZjgtY2YyYjVhNzBmNjgwPC94bXBNTTpJbnN0YW5jZUlEPgogICAgICAgICA8eG1wTU06RG9jdW1lbnRJRD5hZG9iZTpkb2NpZDpwaG90b3Nob3A6ZWI3YmIwYzktZDhiMC0xMWU2LTliZDItYzYyOWNiOTA2ZWQxPC94bXBNTTpEb2N1bWVudElEPgogICAgICAgICA8eG1wTU06T3JpZ2luYWxEb2N1bWVudElEPnhtcC5kaWQ6NThlYzRkNjktOTQzZC1lZjQyLTgzNDItYmY2ZjU4OGM2NzE4PC94bXBNTTpPcmlnaW5hbERvY3VtZW50SUQ+CiAgICAgICAgIDx4bXBNTTpIaXN0b3J5PgogICAgICAgICAgICA8cmRmOlNlcT4KICAgICAgICAgICAgICAgPHJkZjpsaSByZGY6cGFyc2VUeXBlPSJSZXNvdXJjZSI+CiAgICAgICAgICAgICAgICAgIDxzdEV2dDphY3Rpb24+Y3JlYXRlZDwvc3RFdnQ6YWN0aW9uPgogICAgICAgICAgICAgICAgICA8c3RFdnQ6aW5zdGFuY2VJRD54bXAuaWlkOjU4ZWM0ZDY5LTk0M2QtZWY0Mi04MzQyLWJmNmY1ODhjNjcxODwvc3RFdnQ6aW5zdGFuY2VJRD4KICAgICAgICAgICAgICAgICAgPHN0RXZ0OndoZW4+MjAxNy0wMS0xMlQxMTowMjo0NCswNjowMDwvc3RFdnQ6d2hlbj4KICAgICAgICAgICAgICAgICAgPHN0RXZ0OnNvZnR3YXJlQWdlbnQ+QWRvYmUgUGhvdG9zaG9wIENDIDIwMTUgKFdpbmRvd3MpPC9zdEV2dDpzb2Z0d2FyZUFnZW50PgogICAgICAgICAgICAgICA8L3JkZjpsaT4KICAgICAgICAgICAgICAgPHJkZjpsaSByZGY6cGFyc2VUeXBlPSJSZXNvdXJjZSI+CiAgICAgICAgICAgICAgICAgIDxzdEV2dDphY3Rpb24+c2F2ZWQ8L3N0RXZ0OmFjdGlvbj4KICAgICAgICAgICAgICAgICAgPHN0RXZ0Omluc3RhbmNlSUQ+eG1wLmlpZDoxZGJiMTQ1My1hZmQwLWE3NDItODBmOC1jZjJiNWE3MGY2ODA8L3N0RXZ0Omluc3RhbmNlSUQ+CiAgICAgICAgICAgICAgICAgIDxzdEV2dDp3aGVuPjIwMTctMDEtMTJUMTY6MjI6MjArMDY6MDA8L3N0RXZ0OndoZW4+CiAgICAgICAgICAgICAgICAgIDxzdEV2dDpzb2Z0d2FyZUFnZW50PkFkb2JlIFBob3Rvc2hvcCBDQyAyMDE1IChXaW5kb3dzKTwvc3RFdnQ6c29mdHdhcmVBZ2VudD4KICAgICAgICAgICAgICAgICAgPHN0RXZ0OmNoYW5nZWQ+Lzwvc3RFdnQ6Y2hhbmdlZD4KICAgICAgICAgICAgICAgPC9yZGY6bGk+CiAgICAgICAgICAgIDwvcmRmOlNlcT4KICAgICAgICAgPC94bXBNTTpIaXN0b3J5PgogICAgICAgICA8dGlmZjpPcmllbnRhdGlvbj4xPC90aWZmOk9yaWVudGF0aW9uPgogICAgICAgICA8dGlmZjpYUmVzb2x1dGlvbj43MjAwMDAvMTAwMDA8L3RpZmY6WFJlc29sdXRpb24+CiAgICAgICAgIDx0aWZmOllSZXNvbHV0aW9uPjcyMDAwMC8xMDAwMDwvdGlmZjpZUmVzb2x1dGlvbj4KICAgICAgICAgPHRpZmY6UmVzb2x1dGlvblVuaXQ+MjwvdGlmZjpSZXNvbHV0aW9uVW5pdD4KICAgICAgICAgPGV4aWY6Q29sb3JTcGFjZT42NTUzNTwvZXhpZjpDb2xvclNwYWNlPgogICAgICAgICA8ZXhpZjpQaXhlbFhEaW1lbnNpb24+MjI8L2V4aWY6UGl4ZWxYRGltZW5zaW9uPgogICAgICAgICA8ZXhpZjpQaXhlbFlEaW1lbnNpb24+MjI8L2V4aWY6UGl4ZWxZRGltZW5zaW9uPgogICAgICA8L3JkZjpEZXNjcmlwdGlvbj4KICAgPC9yZGY6UkRGPgo8L3g6eG1wbWV0YT4KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAKPD94cGFja2V0IGVuZD0idyI/Pn/Rz3MAAAAgY0hSTQAAeiUAAICDAAD5/wAAgOkAAHUwAADqYAAAOpgAABdvkl/FRgAABXxJREFUeNpsVWlsVFUYvXRa0KiRIBBk04AFwhKstMzc9+7Mu+/NmwXa0mXaaWfeezMlIpoQ4vLDP0pcfhj1B8HEqEQUkSUuQcGl7KtIoFhQRHEhmhhj4rwNre10mzn+eDNFkJt8yb25yflO7jn3O0RVeYWqcl9E5T4e5j45zEk2LpFDreKEbc1s/qbGoHEowV642C5uuZgU3z6aYC9tagyu3t7MFn3RJty6OiaRuMqJovLKMpaq8gpS2lQpKq8Kq5xsagySj1vYA3tbxdeGNdpf0ClGdYpRrVQ6RcE7D3UnxHeOJ8TAc/UhUqtwElV5leqVj5TYVs3hCnkkHiJWiq7NpekgMhT9GoOTEmDfpP7RGJChgE6LW5rYE40RqVJVOYmWGYdV7lsZ4WRtXCKvrmIvwwhgOMNgdgqwWmrgpEU4aRFuSoCTErx9msFqqYHZQdFnhICsH4cT4mYlzIlfkUlU5T7Cw7zi0RUS+T0prIMRQL/OkMvKsFfOhylMgV2/AG5WvtYgK8NpWAxTmAo7Vo1cRsZfRhDI+vFeM9tgRDmJqHwc8SucbGwMLXTSND9sBJHLyjCX3gInJWDg051w2mphBe+Gm5XhdimwpRmwGxZi4LNdcB+MwVxUgZzBMWCEACOAbc2stlbhhOgxafzhBNuKLEWuU4S9Yj6cZADD350HAAydPw0rOB12+F7Y0ftgBiZj8GQ3AGDk15/gZGWPeacAGBRftYmfr4lJE8iG+mD1SJqO5jUGq7UGVt2dGDiyFwBQKBQAAIM9x2Etnwhz6S3I33h39iiswCRYTUvQrzNAp3ixIXg/eb2JrYZO4aREOBqDHZ8Hp8OPoXMnUQQwCm/lD+xG/pPtHiiAIoDhS71w0iLsWDXctAg7JQIGxY5m9hjZ38o2juoUdlnxLIclTIXFZ2Ho7LEx8GKpCqVGwxd7YMXnwfJPgpvhcDURTkrAiEbR08a2k9528d1hjcJJCZ6l0iLcDIel3AOLTcNg9/tjgOUGgyc+h8VnwQpN90DT4pjfh9IUPyTF/eRCO9teBi6X26XAjs6FWXM7BnZv/R9w/sBumMsnwZJnw+1SPCuWgTWKH5PiAXKwlW26/ilk2KHpMOlk5A9+NPYUhRvAh748BEuaCUuYAjd7jfWITtHTxnaRzU1sLXQKu1OEqzHYDYtgNywcU3+M5ZkjyJ/ovk7QwbPHYLfUwF65AFc1EVZKRFGn2NHMniTP1gcXFjQBA1rpm9ZOxMDRTzz1iyX1v78Ai02DWTcRQ72nrrdb7ylYyyfBalyCvpLdNjYE60g2Jo0/lWAfIkOR6xBgR6vhrolh9JfLnvo/X4IdnQs7NAOWPBsWn4nhb854H+SP33B1XTPsyBz8maSAQfFtUjjxcEyaQOoUTt5cxZbBoBgwQshlOMxFPrirVeQP74GjMZiBuzz1szIsYTLsxDIMHt2Lq+sTMOcRmEYI/UYI0APY3SKG6hROSETl41JRiexsCj6NLj/+0oMwDQ4nPg+mNAN2vBqOIXnipEU4GQ575QJY0kzPOVoIri4B2eXoTrBX1sQloqqckKjKK+oUTpgikyMJ9ha6/OgzQsh1UFirFsNNe6KO2THNvLHZuBi5ZAB/Z7yxeblT+KApIlUtlWUSKSdIVOWVLMyJHJartjazp6BTFA2KPo3ddMjbKQF9GkPREFDQKfYk2IsdEem22jAn4VLMjUVTTOWVS2SZPFMfIqfbRel4m7gHOi2MlqJpRBMwogkon4s6RU+7ePBckkWfrw9VLJZlElZ5ZfQ/0VShekHoC6vcF1M5eSguka/bhTs+aGHL3mhij59rZ1uvdIj7rnSI+3rbxW1bmoJP7mll/isdwp3rV0gkHOZEKTEth+m/AwCvClQ5OpFRtgAAAABJRU5ErkJggg==');
    background-position: right;
    background-repeat: no-repeat;
    -moz-box-shadow: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel runat="server" ID="pnlCode" style="margin-bottom: 10px; text-align: center;">
          <div class="input-validation"></div>
        <table>
            <tr>
                <td>
                    <label style="width: 50px;">Code</label>
                </td>
                <td>
                    <asp:TextBox runat="server" required="" pattern="^[0-9]{1,5}$" oninvalid="this.classList.add('customInvalid');setCustomValidity('Invalid product code!')" onkeypress="this.classList.remove('customInvalid');" oninput="setCustomValidity('')" ID="txtProductCode" CssClass="form-control" Width="155px" ClientIDMode="Static" AutoPostBack="true" OnTextChanged="txtProductCode_OnTextChanged"></asp:TextBox>
                    
                </td>

                <td>
                    <label style="margin-left: 50px; width: 50px; ">Name</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" Width="280px" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtProductName_OnTextChanged"></asp:TextBox>
                
                </td>
                <td>
                    <label style="margin-left: 50px; width: 50px">Stock</label>
                </td>
                <td>
                    <div class = "input-group">
                           <asp:TextBox runat="server" ID="txtProductStock" CssClass="form-control" Width="100px" style=""  BackColor="#F8F8F8" ReadOnly="True" Enabled="False" TabIndex="-1"></asp:TextBox>                    
                           <asp:Label runat="server" ID="lblUnit" CssClass = "input-group-addon" Text="Unit" style="min-width: 80px;" TabIndex="-1"></asp:Label>

                      </div>
                </td>
                <td>
                    <label style="margin-left: 50px; width: 50px">Price</label>
                </td>
                <td>
                     <div class = "input-group">
                         <asp:TextBox runat="server" ID="txtProductPricePerUnit" CssClass="form-control" Width="120px" BackColor="#F8F8F8" ReadOnly="True" Enabled="False" TabIndex="-1"></asp:TextBox>
       
                         <span class = "input-group-addon">BDT</span>
                      </div>
                    
               
                </td>
                
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
    </asp:Panel>
   
    <asp:Panel runat="server" ID="pnlQty" style="margin-bottom: 10px; text-align: center;">
          
        <table>
            <tr>
                <td>
                    <label style="width: 50px;">Qty</label>
                </td>
                <td>
                    <div class = "input-group">
                           <asp:TextBox runat="server" required="" pattern="^\d+(\.\d{1,3})?$" oninvalid="this.classList.add('customInvalid');setCustomValidity('Invalid Qty!')" onkeypress="this.classList.remove('customInvalid');" ID="txtQty" CssClass="form-control" Width="75px" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtQty_OnTextChanged"></asp:TextBox>                    
                           <asp:Label runat="server" ID="lblUnitSell" CssClass = "input-group-addon" Text="Unit" style="min-width: 80px" TabIndex="-1"></asp:Label>

                      </div>
                </td>
                <td>
                    <label style="margin-left: 50px; width: 50px">Price</label>
                </td>
                
                <td>
                    <div class = "input-group">
                
                    
                         <asp:TextBox runat="server" ID="txtTotalPriceOfWholeQty" CssClass="form-control" Width="120px" ReadOnly="True" Enabled="False" TabIndex="-1"></asp:TextBox>
       
                         <span class = "input-group-addon">BDT</span>
                      </div>                 
                </td>
                <td>
                    <label style="margin-left: 157px; width: 50px">VAT</label>
                </td>
                <td>
                   <div class = "input-group">
                
                    
                         <asp:TextBox runat="server" ID="txtVat" CssClass="form-control" Width="143px" ReadOnly="True" Enabled="False" TabIndex="-1"></asp:TextBox>
       
                         <span class = "input-group-addon">%</span>
                      </div> 
                </td>
                <td>
                    <label style="margin-left: 50px; width: 50px">Total Price</label>
                </td>
                <td>
                    <div class = "input-group">
                
                    
                         <asp:TextBox runat="server" ID="txtTotalPriceOfWholeProduct" CssClass="form-control" Width="120px" ReadOnly="True" Enabled="False" TabIndex="-1"></asp:TextBox>
       
                         <span class = "input-group-addon">BDT</span>
                      </div> 
                </td>
              
                
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlAddButton" style="margin-left: 50px;">
        <asp:Button runat="server" ID="btnAdd" OnClientClick="ccfn1()" Text="Add" CssClass="btn btn-primary" Width="155px" ClientIDMode="Static" OnClick="btnAdd_Click" />
    </asp:Panel>
    <br/>
    <asp:Panel runat="server" ID="pnlsaleGridview" style="text-align: center;" Visible="False">
        <asp:GridView runat="server" ID="GvSellProduct" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="ProductId"
            ShowHeaderWhenEmpty="True" EmptyDataText="No product sell yet." OnRowDataBound="GvSellProduct_OnRowDataBound" ShowFooter="True" OnRowDeleting="GvSellProduct_OnRowDeleting">
            <HeaderStyle CssClass="gvheaderstyle"></HeaderStyle>
            <RowStyle CssClass="gvrowstyle"></RowStyle>
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="Product Id" Visible="False"/>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name"/>
                <asp:BoundField DataField="ProductQty" HeaderText="Quantity"/>
                <asp:BoundField DataField="ProductPricePerUnit" HeaderText="Price Per Unit"/>
                <asp:BoundField DataField="ProductVat" HeaderText="VAT(%)"/>
                <asp:BoundField DataField="ProductTotalPrice" HeaderText="Total Price"/>
                <asp:CommandField HeaderText="Action" ButtonType="Button" ShowDeleteButton="True" CausesValidation="False" />
            </Columns>
            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" NextPageText="Next" LastPageText="Last" PreviousPageText="Previous"></PagerSettings>
            <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />

        </asp:GridView>
        
    </asp:Panel>
    <br/>
    <asp:Panel runat="server" ID="pnlId" style="margin-bottom: 10px; text-align: center;">
          
        <table>
            <tr>
                <td>
                    <label style="width: 50px; text-indent: -20px">Username</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustomerUsername" CssClass="form-control" Width="155px" ClientIDMode="Static" AutoPostBack="True" Placeholder="Customer Username" OnTextChanged="txtCustomerUsername_OnTextChanged"></asp:TextBox>
                    
                </td>
                <td>
                    <label style="margin-left: 20px; width: 80px">Name</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustomerFullName" CssClass="form-control" Width="173px" ClientIDMode="Static" AutoPostBack="True" Placeholder="Customer Full Name" OnTextChanged="txtCustomerFullName_OnTextChanged"></asp:TextBox>
                </td>
                <td>
                    <label style="margin-left: 117px; width: 90px">Contact No.</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustomerContactNo" CssClass="form-control" Width="180px" ClientIDMode="Static" AutoPostBack="True" Placeholder="Customer Contact No." OnTextChanged="txtCustomerContactNo_OnTextChanged"></asp:TextBox>
                </td>
                
                <td>
                    <label style="margin-left: 50px; width: 50px">Due</label>
                </td>
                <td>
                    <div class = "input-group">
                
                         <asp:TextBox runat="server" ID="txtCustomerDue" CssClass="form-control" Width="120px" ReadOnly="True" Enabled="False" TabIndex="-1"></asp:TextBox>
       
                         <span class = "input-group-addon">BDT</span>
                      </div>                    
                </td>
            </tr>
        </table>
    </asp:Panel>
    
   
    <asp:Panel runat="server" ID="pnlDiscount" style="margin-bottom: 10px; text-align: center;">
          
        <table>
            <tr>
                <td>
                    <label style="text-indent: -15px;width: 50px">Discount</label>
                </td>
                <td>
                    <div class = "input-group">
                
                    
                         <asp:TextBox runat="server" pattern="^\d+(\.\d{1,2})?$" oninvalid="this.classList.add('customInvalid');setCustomValidity('Invalid amount!')" onkeypress="this.classList.remove('customInvalid');" oninput="setCustomValidity('')" ID="txtDiscount" CssClass="form-control" Width="102px" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtDiscount_OnTextChanged"></asp:TextBox>
       
                         <span class = "input-group-addon">BDT</span>
                      </div>
                </td>
                <td>
                    <label style="margin-left: 20px; width: 80px">Customer Name</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustomerNameAnonymous" CssClass="form-control" Width="173px" ClientIDMode="Static" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>
                    <label style="margin-left: 80px;width: 127px">Payment Method</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlPaymentMethod" CssClass="form-control" Width="180px" ClientIDMode="Static">
                        <asp:ListItem Text="Cash" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Cheque " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Credit Card" Value="3"></asp:ListItem>
                        <asp:ListItem Text="bKash" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Roket" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <label style="margin-left: 20px; width: 80px">To Be Paid</label>
                </td>
                <td>
                    <div class = "input-group">
                
                    
                         <asp:TextBox runat="server" ID="txtToBePaid" CssClass="form-control" Width="120px" ReadOnly="True" Enabled="False" TabIndex="-1" ForeColor="Red"  BackColor="#F8F8F8" Font-Bold="True"></asp:TextBox>
       
                         <span class = "input-group-addon">BDT</span>
                      </div> 
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlAmountPaid" style="margin-bottom: 10px; text-align: center;">
          
        <table>
            <tr>
                <td>
                    <label style="width: 50px; text-indent: -10px">Amount Paid</label>
                </td>
                <td>
                    <div class = "input-group">
                    <asp:TextBox runat="server" required="" pattern="^\d+(\.\d{1,2})?$" oninvalid="this.classList.add('customInvalid');setCustomValidity('Invalid amount!')" onkeypress="this.classList.remove('customInvalid');" oninput="setCustomValidity('')" ID="txtAmountPaid" CssClass="form-control" Width="102px" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtAmountPaid_OnTextChanged"></asp:TextBox>                    
                         <span class = "input-group-addon">BDT</span>

                      </div>
                </td>
                <td>
                    <label style="margin-left: 20px; width: 80px">Change Amount</label>
                </td>
                
                <td>
                    <div class = "input-group">
                
                    
                         <asp:TextBox runat="server" ID="txtChangeAmount" CssClass="form-control" Width="120px" ReadOnly="True" Enabled="False" TabIndex="-1"></asp:TextBox>
       
                         <span class = "input-group-addon">BDT</span>
                      </div>                 
                </td>
                <td>
                    <label style="margin-left: 134px; width: 72px">Remarks</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" Width="454px" Height="34px" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
   
    
    <asp:Panel runat="server" ID="pnlsale" style="margin-left: 50px;" Visible="True">
        <asp:Button runat="server" ID="btnSell" OnClientClick="ccfn()" CssClass="btn btn-primary" CausesValidation="false" Text="Sell" ClientIDMode="Static" Width="155px" OnClick="btnSell_OnClick"/>
    </asp:Panel>
   <br />
    
</asp:Content>
