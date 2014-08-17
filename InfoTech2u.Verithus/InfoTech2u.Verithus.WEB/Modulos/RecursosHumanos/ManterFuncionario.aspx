﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterFuncionario.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Funcionario.ManterFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {


            jQuery('.taglist .close').click(function () {
                jQuery(this).parent().remove();
                return false;
            });

        });
    </script>
    <div class="rightpanel">
        
        <ul class="breadcrumbs">
            <li><a href="dashboard.html"><i class="iconfa-home"></i></a> <span class="separator"></span></li>
            <li><a href="editprofile.html">Other Pages</a> <span class="separator"></span></li>
            <li>Edit Profile</li>
            
            <li class="right">
                <a href="" data-toggle="dropdown" class="dropdown-toggle"><i class="icon-tint"></i> Color Skins</a>
                <ul class="dropdown-menu pull-right skin-color">
                    <li><a href="default">Default</a></li>
                    <li><a href="navyblue">Navy Blue</a></li>
                    <li><a href="palegreen">Pale Green</a></li>
                    <li><a href="red">Red</a></li>
                    <li><a href="green">Green</a></li>
                    <li><a href="brown">Brown</a></li>
                </ul>
            </li>
        </ul>
        
        <div class="pageheader">
            <form action="results.html" method="post" class="searchbar">
                <input type="text" name="keyword" placeholder="To search type and hit enter..." />
            </form>
            <div class="pageicon"><span class="iconfa-laptop"></span></div>
            <div class="pagetitle">
                <h5>Sample Text Here</h5>
                <h1>Edit Profile</h1>
            </div>
        </div><!--pageheader-->
        
        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row-fluid">
                    	<div class="span4 profile-left">
                        
                        <div class="widgetbox profile-photo">
                            <div class="headtitle">
                                <div class="btn-group">
                                    <button data-toggle="dropdown" class="btn dropdown-toggle">Action <span class="caret"></span></button>
                                    <ul class="dropdown-menu">
                                      <li><a href="#">Change Photo</a></li>
                                      <li><a href="#">Remove Photo</a></li>
                                    </ul>
                                </div>
                                <h4 class="widgettitle">Profile Photo</h4>
                            </div>
                            <div class="widgetcontent">
                                <div class="profilethumb">
                                    <img src="images/profilethumb.png" alt="" class="img-polaroid" />
                                </div><!--profilethumb-->
                            </div>
                        </div>
                            
                            
                        <div class="widgetbox tags">
                                <h4 class="widgettitle">Tags</h4>
                                <div class="widgetcontent">
                                    <ul class="taglist">
                                        <li><a href="">HTML5 <span class="close">&times;</span></a></li>
                                        <li><a href="">CSS <span class="close">&times;</span></a></li>
                                        <li><a href="">PHP <span class="close">&times;</span></a></li>
                                        <li><a href="">jQuery <span class="close">&times;</span></a></li>
                                        <li><a href="">Java <span class="close">&times;</span></a></li>
                                        <li><a href="">GWT <span class="close">&times;</span></a></li>
                                        <li><a href="">CodeNgniter <span class="close">&times;</span></a></li>
                                        <li><a href="">Bootstrap <span class="close">&times;</span></a></li>
                                    </ul>
                                    <a href="" style="display:block;margin-top:10px">+ Add Tag</a>
                                </div>
                        </div>
                            
                        </div><!--span4-->
                        <div class="span8">
                            <form action="editprofile.html" class="editprofileform" method="post">
                                
                                <div class="widgetbox login-information">
                                    <h4 class="widgettitle">Login Information</h4>
                                    <div class="widgetcontent">
                                        <p>
                                            <label>Username:</label>
                                            <input type="text" name="username" class="input-xlarge" value="themepixels" />
                                        </p>
                                        <p>
                                            <label>Email:</label>
                                            <input type="text" name="email" class="input-xlarge" value="you@yourdomain.com" />
                                        </p>
                                        <p>
                                            <label style="padding:0">Password</label>
                                            <a href="">Change Password?</a>
                                        </p>
                                    </div>
                                </div>
                                
                                
                                <div class="widgetbox personal-information">
                                    <h4 class="widgettitle">Personal Information</h4>
                                    <div class="widgetcontent">
                                        <p>
                                            <label>Firstname:</label>
                                            <input type="text" name="firstname" class="input-xlarge" value="Theme" />
                                        </p>
                                        <p>
                                            <label>Lastname:</label>
                                            <input type="text" name="lastname" class="input-xlarge" value="Pixels" />
                                        </p>
                                        <p>
                                            <label>Location:</label>
                                            <input type="text" name="location" class="input-xlarge" value="Cebu, Philippines" />
                                        </p>
                                        <p>
                                            <label>Your Website:</label>
                                            <input type="text" name="website" class="input-xlarge" value="http://themepixels.com/" />
                                        </p>
                                        <p>
                                            <label>About You:</label>
                                            <textarea name="about" class="span8"></textarea>
                                        </p>
                                    </div>
                                </div>
                                
                                <div class="widgetbox profile-notifications">
                                    <h4 class="widgettitle">Notifications</h4>
                                    <div class="widgetcontent">
                                        <p>
                                            <input type="checkbox" /> Email me when someone mentions me... <br />
                                            <input type="checkbox" /> Email me when someone follows me...
                                        </p>
                                    </div>
                                </div>
                                
                                <p>
                                	<button type="submit" class="btn btn-primary">Update Profile</button> &nbsp; <a href="">Deactivate your account</a>
                                </p>
                                
                            </form>
                        </div><!--span8-->
                    </div><!--row-fluid-->
                    
                    <div class="footer">
                        <div class="footer-left">
                            <span>&copy; 2013. Shamcey Admin Template. All Rights Reserved.</span>
                        </div>
                        <div class="footer-right">
                            <span>Designed by: <a href="http://themepixels.com/">ThemePixels</a></span>
                        </div>
                    </div><!--footer-->
                
            </div><!--maincontentinner-->
        </div><!--maincontent-->
        
    </div><!--rightpanel-->
</asp:Content>
