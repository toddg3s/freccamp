<!DOCTYPE html>
<html lang="en">
<head>
    <title>Search Results</title>
    <meta charset="utf-8">
    <meta name="format-detection" content="telephone=no"/>
    <link rel="icon" href="images/favicon.ico" type="image/x-icon">
    <link rel="stylesheet" href="css/grid.css">
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/search.css"/>

    <script src="js/jquery.js"></script>
    <script src="js/jquery-migrate-1.2.1.js"></script>

    <!--[if lt IE 9]>
    <html class="lt-ie9">
    <div style=' clear: both; text-align:center; position: relative;'>
        <a href="http://windows.microsoft.com/en-US/internet-explorer/..">
            <img src="images/ie8-panel/warning_bar_0000_us.jpg" border="0" height="42" width="820"
                 alt="You are using an outdated browser. For a faster, safer browsing experience, upgrade for free today."/>
        </a>
    </div>
    <script src="js/html5shiv.js"></script>    
  	<script src='js/selectivizr-min.js'></script>
    <![endif]-->

    <script src='js/device.min.js'></script>
</head>

<body>
<div class="page">
  <div class="wrap">
     <!--========================================================
                              HEADER
    =========================================================-->
    <header class="bg01">
      <div class="bb">
        <div class="container">
          <div class="brand">
            <h1 class="brand_name">
              <a href="./">Taekwondo Times</a>
            </h1>
          </div>
        </div>
      </div>
      <div id="stuck_container" class="stuck_container">
        <div class="container bg01">
          <nav class="nav">
            <ul class="sf-menu" data-type="navbar">
              <li>
                <a href="./">Home</a>
              </li>
              <li>
                <a href="index-1.html">About us</a>
                <ul>
                  <li>
                    <a href="#">Mauris accumsan</a>
                    <ul>
                      <li>
                        <a href="#">Sit amet</a>
                      </li>
                      <li>
                        <a href="#">Consectetuer</a>
                      </li>
                      <li>
                        <a href="#">Adipiscing elit</a>
                      </li>
                      <li>
                        <a href="#">Pellentesque</a>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <a href="#">Nulla vel diam</a>
                  </li>
                  <li>
                    <a href="#">Sed in lacus ut</a>
                  </li>
                  <li>
                    <a href="#">Enim adipiscing</a>
                  </li>
                </ul>
              </li>
              <li>
                <a href="index-2.html">News & events</a>
              </li>
              <li>
                <a href="index-3.html">Gallery</a>
              </li>
              <li>
                <a href="index-4.html">Contacts</a>
              </li>
            </ul>
          </nav>
          <div class="search-wrap">
            <a class="search-form_toggle" href="#"></a>
            <form class="search-form" action="search.php" method="GET" accept-charset="utf-8">
              <label class="search-form_label">
                <input class="search-form_input" type="text" name="s" autocomplete="off" placeholder="Search.."/>
                <span class="search-form_liveout"></span>
              </label>
              <button class="search-form_submit fa-search" type="submit"></button>
            </form>
          </div>
        </div>
      </div>
    </header>
    <!--========================================================
                              CONTENT
    =========================================================-->
    <main class="bg03">
        <section id="content" class="content well02">
            <div class="container">
                <h4>Search Results</h4>
                <div id="search-results"></div>
            </div>
        </section>
    </main>

    <!--========================================================
                              FOOTER
    =========================================================-->
    <footer id="footer" class="footer">
        <div class="wrap">
          <div class="container">
            <p class="copy">
              Taekwondo Times © <span id="copyright-year"></span> All Rights Reserved&nbsp; |&nbsp;
              <a href="index-5.html">Privacy Policy</a>
            </p>
          </div>
        </div> 
    </footer>
  </div>
</div>

<script src="js/script.js"></script>

</body>
</html>