<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FcmDemo.index" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Push Codelab</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link rel="stylesheet" href="https://code.getmdl.io/1.2.1/material.indigo-pink.min.css">
    <script defer src="https://code.getmdl.io/1.2.1/material.min.js"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
</head>
<body>
    <link rel="stylesheet" href="<%=baseUrl%>/styles/index.css">
     <script>
         var __GLOBAL_AJAX_BASE_URL = "<%=baseUrl%>/ajax.aspx";
         var __GLOBAL_FCM_CONFIG = {
             apiKey: "<%=configApiKey%>",
             authDomain: "<%=configAuthDomain%>",
             messagingSenderId: "<%=configSenderId%>"
         };
    </script>
    <header>
        <h1>Push Codelab</h1>
    </header>
    <script src="https://www.gstatic.com/firebasejs/3.6.6/firebase.js"></script>
    <script src="<%=baseUrl%>/scripts/main.js"></script>
    <script src="https://code.getmdl.io/1.2.1/material.min.js"></script>
</body>
</html>
