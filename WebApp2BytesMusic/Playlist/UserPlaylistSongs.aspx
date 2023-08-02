﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPlaylistSongs.aspx.cs" Inherits="WebApp2BytesMusic.Playlist.UserPlaylistSongs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.3.0/css/font-awesome.min.css'>
    <style>
@charset "UTF-8";
@import "//cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.css";
.screen-reader-text {
  /* Reusable, toolbox kind of class */
  position: absolute;
  top: -9999px;
  left: -9999px;
}

.disabled {
  color: #666;
  cursor: default;
}

.show {
  display: inline-block !important;
}

body {
  margin: 10px 0 0 0;
}
body .container {
  font-family: arial, helvetica, sans-serif;
  font-size: 1em;
  margin: 0 auto;
  width: 500px;
}
body .container .player {
  height: 60px;
  margin: 0;
  position: relative;
  width: 400px;
  /* Small devices (tablets, 768px and up) */
  /* Medium devices (desktops, 992px and up) */
  /* Large devices (large desktops, 1200px and up) */
  *zoom: 1;
}
@media (min-width: 768px) and (max-width: 991px) {
  body .container .player {
    width: 470px;
  }
}
@media (min-width: 992px) and (max-width: 1100px) {
  body .container .player {
    width: 470px;
  }
}
@media (min-width: 1200px) {
  body .container .player {
    width: 470px;
  }
}
body .container .player .large-toggle-btn {
  border: 1px solid #d9d9d9;
  border-radius: 2px;
  float: left;
  font-size: 1.5em;
  height: 50px;
  margin: 0 10px 0 0;
  overflow: hidden;
  padding: 5px 0 0 0;
  position: relative;
  text-align: center;
  vertical-align: bottom;
  width: 54px;
}
body .container .player .large-toggle-btn .large-play-btn {
  cursor: pointer;
  display: inline-block;
  position: relative;
  top: -14%;
}
body .container .player .large-toggle-btn .large-play-btn:before {
  content: "\f04b";
  font: 1.5em/1.75 "FontAwesome";
}
body .container .player .large-toggle-btn .large-pause-btn {
  cursor: pointer;
  display: inline-block;
  position: relative;
  top: -13%;
}
body .container .player .large-toggle-btn .large-pause-btn:before {
  content: "\f04c";
  font: 1.5em/1.75 "FontAwesome";
}
body .container .player .info-box {
  bottom: 10px;
  left: 65px;
  position: absolute;
  top: 15px;
}
body .container .player .info-box .track-info-box {
  float: left;
  font-size: 12px;
  margin: 0 0 6px 0;
  visibility: hidden;
  width: 400px;
  *zoom: 1;
}
body .container .player .info-box .track-info-box .track-title-text {
  display: inline-block;
}
body .container .player .info-box .track-info-box .audio-time {
  display: inline-block;
  padding: 0 0 0 5px;
  width: 80px;
}
body .container .player .info-box .track-info-box:before, body .container .player .info-box .track-info-box:after {
  content: " ";
  display: table;
}
body .container .player .info-box .track-info-box:after {
  clear: both;
  display: block;
  font-size: 0;
  height: 0;
  visibility: hidden;
}
body .container .player .progress-box {
  float: left;
  min-width: 270px;
  position: relative;
}
body .container .player .progress-box .progress-cell {
  height: 12px;
  position: relative;
}
body .container .player .progress-box .progress-cell .progress {
  background: #fff;
  border: 1px solid #d9d9d9;
  height: 8px;
  position: relative;
  width: auto;
}
body .container .player .progress-box .progress-cell .progress .progress-buffer {
  background: #337ab7;
  height: 100%;
  width: 0;
}
body .container .player .progress-box .progress-cell .progress .progress-indicator {
  background: #fff;
  border: 1px solid #bebebe;
  border-radius: 3px;
  cursor: pointer;
  height: 10px;
  left: 0;
  overflow: hidden;
  position: absolute;
  top: -2px;
  width: 22px;
}
body .container .player .controls-box {
  bottom: 10px;
  left: 350px;
  position: absolute;
}
body .container .player .controls-box .previous-track-btn {
  cursor: pointer;
  display: inline-block;
}
body .container .player .controls-box .previous-track-btn:before {
  content: "\f049";
  font: 1em "FontAwesome";
}
body .container .player .controls-box .next-track-btn {
  cursor: pointer;
  display: inline-block;
}
body .container .player .controls-box .next-track-btn:before {
  content: "\f050";
  font: 1em "FontAwesome";
}
body .container .player:before, body .container .player:after {
  content: " ";
  display: table;
}
body .container .player:after {
  clear: both;
  display: block;
  font-size: 0;
  height: 0;
  visibility: hidden;
}
body .container .play-list {
  display: block;
  margin: 0 auto 20px auto;
  width: 100%;
}
body .container .play-list .play-list-row {
  display: block;
  margin: 10px 0;
  width: 100%;
  *zoom: 1;
}
body .container .play-list .play-list-row .track-title .playlist-track {
  color: #000;
  text-decoration: none;
}
body .container .play-list .play-list-row .track-title .playlist-track:hover {
  text-decoration: underline;
}
body .container .play-list .play-list-row .small-toggle-btn {
  border: 1px solid #d9d9d9;
  border-radius: 2px;
  cursor: pointer;
  display: inline-block;
  height: 20px;
  margin: 0 auto;
  overflow: hidden;
  position: relative;
  text-align: center;
  vertical-align: middle;
  width: 20px;
}
body .container .play-list .play-list-row .small-toggle-btn .small-play-btn {
  display: inline-block;
}
body .container .play-list .play-list-row .small-toggle-btn .small-play-btn:before {
  content: "\f04b";
  font: 0.85em "FontAwesome";
}
body .container .play-list .play-list-row .small-toggle-btn .small-pause-btn {
  display: inline-block;
}
body .container .play-list .play-list-row .small-toggle-btn .small-pause-btn:before {
  content: "\f04c";
  font: 0.85em "FontAwesome";
}
body .container .play-list .play-list-row .track-number {
  display: inline-block;
}
body .container .play-list .play-list-row .track-title {
  display: inline-block;
}
body .container .play-list .play-list-row .track-title .playlist-track {
  text-decoration: none;
}
body .container .play-list .play-list-row .track-title .playlist-track:hover {
  text-decoration: underline;
}
body .container .play-list .play-list-row .track-title.active-track {
  font-weight: bold;
}
body .container .play-list .play-list-row:before, body .container .play-list .play-list-row:after {
  content: " ";
  display: table;
}
body .container .play-list .play-list-row:after {
  clear: both;
  display: block;
  font-size: 0;
  height: 0;
  visibility: hidden;
}
</style>

          <script id="rendered-js" >
var audioPlayer = function () {
  "use strict";

  // Private variables
  var _currentTrack = null;
  var _elements = {
    audio: document.getElementById("audio"),
    playerButtons: {
      largeToggleBtn: document.querySelector(".large-toggle-btn"),
      nextTrackBtn: document.querySelector(".next-track-btn"),
      previousTrackBtn: document.querySelector(".previous-track-btn"),
      smallToggleBtn: document.getElementsByClassName("small-toggle-btn") },

    progressBar: document.querySelector(".progress-box"),
    playListRows: document.getElementsByClassName("play-list-row"),
    trackInfoBox: document.querySelector(".track-info-box") };

  var _playAHead = false;
  var _progressCounter = 0;
  var _progressBarIndicator = _elements.progressBar.children[0].children[0].children[1];
  var _trackLoaded = false;

  /**
   * Determines the buffer progress.
   *
   * @param audio The audio element on the page.
   **/
  var _bufferProgress = function (audio) {
    var bufferedTime = audio.buffered.end(0) * 100 / audio.duration;
    var progressBuffer = _elements.progressBar.children[0].children[0].children[0];

    progressBuffer.style.width = bufferedTime + "%";
  };

  /**
   * A utility function for getting the event cordinates based on browser type.
   *
   * @param e The JavaScript event.
   **/
  var _getXY = function (e) {
    var containerX = _elements.progressBar.offsetLeft;
    var containerY = _elements.progressBar.offsetTop;

    var coords = {
      x: null,
      y: null };


    var isTouchSuopported = ("ontouchstart" in window);

    if (isTouchSuopported) {//For touch devices
      coords.x = e.clientX - containerX;
      coords.y = e.clientY - containerY;

      return coords;
    } else if (e.offsetX || e.offsetX === 0) {// For webkit browsers
      coords.x = e.offsetX;
      coords.y = e.offsetY;

      return coords;
    } else if (e.layerX || e.layerX === 0) {// For Mozilla firefox
      coords.x = e.layerX;
      coords.y = e.layerY;

      return coords;
    }
  };

  var _handleProgressIndicatorClick = function (e) {
    var progressBar = document.querySelector(".progress-box");
    var xCoords = _getXY(e).x;

    return (xCoords - progressBar.offsetLeft) / progressBar.children[0].offsetWidth;
  };

  /**
   * Initializes the html5 audio player and the playlist.
   *
   **/
  var initPlayer = function () {

    if (_currentTrack === 1 || _currentTrack === null) {
      _elements.playerButtons.previousTrackBtn.disabled = true;
    }

    //Adding event listeners to playlist clickable elements.
    for (var i = 0; i < _elements.playListRows.length; i++) {if (window.CP.shouldStopExecution(0)) break;
      var smallToggleBtn = _elements.playerButtons.smallToggleBtn[i];
      var playListLink = _elements.playListRows[i].children[2].children[0];

      //Playlist link clicked.
      playListLink.addEventListener("click", function (e) {
        e.preventDefault();
        var selectedTrack = parseInt(this.parentNode.parentNode.getAttribute("data-track-row"));

        if (selectedTrack !== _currentTrack) {
          _resetPlayStatus();
          _currentTrack = null;
          _trackLoaded = false;
        }

        if (_trackLoaded === false) {
          _currentTrack = parseInt(selectedTrack);
          _setTrack();
        } else {
          _playBack(this);
        }
      }, false);

      //Small toggle button clicked.
      smallToggleBtn.addEventListener("click", function (e) {
        e.preventDefault();
        var selectedTrack = parseInt(this.parentNode.getAttribute("data-track-row"));

        if (selectedTrack !== _currentTrack) {
          _resetPlayStatus();
          _currentTrack = null;
          _trackLoaded = false;
        }

        if (_trackLoaded === false) {
          _currentTrack = parseInt(selectedTrack);
          _setTrack();
        } else {
          _playBack(this);
        }

      }, false);
    }

    //Audio time has changed so update it.
    window.CP.exitedLoop(0);_elements.audio.addEventListener("timeupdate", _trackTimeChanged, false);

    //Audio track has ended playing.
    _elements.audio.addEventListener("ended", function (e) {
      _trackHasEnded();
    }, false);

    //Audio error. 
    _elements.audio.addEventListener("error", function (e) {
      switch (e.target.error.code) {
        case e.target.error.MEDIA_ERR_ABORTED:
          alert('You aborted the video playback.');
          break;
        case e.target.error.MEDIA_ERR_NETWORK:
          alert('A network error caused the audio download to fail.');
          break;
        case e.target.error.MEDIA_ERR_DECODE:
          alert('The audio playback was aborted due to a corruption problem or because the video used features your browser did not support.');
          break;
        case e.target.error.MEDIA_ERR_SRC_NOT_SUPPORTED:
          alert('The video audio not be loaded, either because the server or network failed or because the format is not supported.');
          break;
        default:
          alert('An unknown error occurred.');
          break;}

      trackLoaded = false;
      _resetPlayStatus();
    }, false);

    //Large toggle button clicked.
    _elements.playerButtons.largeToggleBtn.addEventListener("click", function (e) {
      if (_trackLoaded === false) {
        _currentTrack = parseInt(1);
        _setTrack();
      } else {
        _playBack();
      }
    }, false);

    //Next track button clicked.
    _elements.playerButtons.nextTrackBtn.addEventListener("click", function (e) {
      if (this.disabled !== true) {
        _currentTrack++;
        _trackLoaded = false;
        _resetPlayStatus();
        _setTrack();
      }
    }, false);

    //Previous track button clicked.
    _elements.playerButtons.previousTrackBtn.addEventListener("click", function (e) {
      if (this.disabled !== true) {
        _currentTrack--;
        _trackLoaded = false;
        _resetPlayStatus();
        _setTrack();
      }
    }, false);

    //User is moving progress indicator.
    _progressBarIndicator.addEventListener("mousedown", _mouseDown, false);

    //User stops moving progress indicator.
    window.addEventListener("mouseup", _mouseUp, false);
  };

  /**
   * Handles the mousedown event by a user and determines if the mouse is being moved.
   *
   * @param e The event object.
   **/
  var _mouseDown = function (e) {
    window.addEventListener("mousemove", _moveProgressIndicator, true);
    audio.removeEventListener("timeupdate", _trackTimeChanged, false);

    _playAHead = true;
  };

  /**
   * Handles the mouseup event by a user.
   *
   * @param e The event object.
   **/
  var _mouseUp = function (e) {
    if (_playAHead === true) {
      var duration = parseFloat(audio.duration);
      var progressIndicatorClick = parseFloat(_handleProgressIndicatorClick(e));
      window.removeEventListener("mousemove", _moveProgressIndicator, true);

      audio.currentTime = duration * progressIndicatorClick;
      audio.addEventListener("timeupdate", _trackTimeChanged, false);
      _playAHead = false;
    }
  };

  /**
   * Moves the progress indicator to a new point in the audio.
   *
   * @param e The event object.
   **/
  var _moveProgressIndicator = function (e) {
    var newPosition = 0;
    var progressBarOffsetLeft = _elements.progressBar.offsetLeft;
    var progressBarWidth = 0;
    var progressBarIndicator = _elements.progressBar.children[0].children[0].children[1];
    var progressBarIndicatorWidth = _progressBarIndicator.offsetWidth;
    var xCoords = _getXY(e).x;

    progressBarWidth = _elements.progressBar.children[0].offsetWidth - progressBarIndicatorWidth;
    newPosition = xCoords - progressBarOffsetLeft;

    if (newPosition >= 1 && newPosition <= progressBarWidth) {
      progressBarIndicator.style.left = newPosition + ".px";
    }
    if (newPosition < 0) {
      progressBarIndicator.style.left = "0";
    }
    if (newPosition > progressBarWidth) {
      progressBarIndicator.style.left = progressBarWidth + "px";
    }
  };

  /**
   * Controls playback of the audio element.
   *
   **/
  var _playBack = function () {
    if (_elements.audio.paused) {
      _elements.audio.play();
      _updatePlayStatus(true);
      document.title = "\u25B6 " + document.title;
    } else {
      _elements.audio.pause();
      _updatePlayStatus(false);
      document.title = document.title.substr(2);
    }
  };

  /**
   * Sets the track if it hasn't already been loaded yet.
   *
   **/
  var _setTrack = function () {
    var songURL = _elements.audio.children[_currentTrack - 1].src;

    _elements.audio.setAttribute("src", songURL);
    _elements.audio.load();

    _trackLoaded = true;

    _setTrackTitle(_currentTrack, _elements.playListRows);

    _setActiveItem(_currentTrack, _elements.playListRows);

    _elements.trackInfoBox.style.visibility = "visible";

    _playBack();
  };

  /**
   * Sets the activly playing item within the playlist.
   *
   * @param currentTrack The current track number being played.
   * @param playListRows The playlist object.
   **/
  var _setActiveItem = function (currentTrack, playListRows) {
    for (var i = 0; i < playListRows.length; i++) {if (window.CP.shouldStopExecution(1)) break;
      playListRows[i].children[2].className = "track-title";
    }window.CP.exitedLoop(1);

    playListRows[currentTrack - 1].children[2].className = "track-title active-track";
  };

  /**
   * Sets the text for the currently playing song.
   *
   * @param currentTrack The current track number being played.
   * @param playListRows The playlist object.
   **/
  var _setTrackTitle = function (currentTrack, playListRows) {
    var trackTitleBox = document.querySelector(".player .info-box .track-info-box .track-title-text");
    var trackTitle = playListRows[currentTrack - 1].children[2].outerText;

    trackTitleBox.innerHTML = null;

    trackTitleBox.innerHTML = trackTitle;

    document.title = trackTitle;
  };

  /**
   * Plays the next track when a track has ended playing.
   *
   **/
  var _trackHasEnded = function () {
    parseInt(_currentTrack);
    _currentTrack = _currentTrack === _elements.playListRows.length ? 1 : _currentTrack + 1;
    _trackLoaded = false;

    _resetPlayStatus();

    _setTrack();
  };

  /**
   * Updates the time for the song being played.
   *
   **/
  var _trackTimeChanged = function () {
    var currentTimeBox = document.querySelector(".player .info-box .track-info-box .audio-time .current-time");
    var currentTime = audio.currentTime;
    var duration = audio.duration;
    var durationBox = document.querySelector(".player .info-box .track-info-box .audio-time .duration");
    var trackCurrentTime = _trackTime(currentTime);
    var trackDuration = _trackTime(duration);

    currentTimeBox.innerHTML = null;
    currentTimeBox.innerHTML = trackCurrentTime;

    durationBox.innerHTML = null;
    durationBox.innerHTML = trackDuration;

    _updateProgressIndicator(audio);
    _bufferProgress(audio);
  };

  /**
   * A utility function for converting a time in miliseconds to a readable time of minutes and seconds.
   *
   * @param seconds The time in seconds.
   *
   * @return time The time in minutes and/or seconds.
   **/
  var _trackTime = function (seconds) {
    var min = 0;
    var sec = Math.floor(seconds);
    var time = 0;

    min = Math.floor(sec / 60);

    min = min >= 10 ? min : '0' + min;

    sec = Math.floor(sec % 60);

    sec = sec >= 10 ? sec : '0' + sec;

    time = min + ':' + sec;

    return time;
  };

  /**
   * Updates both the large and small toggle buttons accordingly.
   *
   * @param audioPlaying A booean value indicating if audio is playing or paused.
   **/
  var _updatePlayStatus = function (audioPlaying) {
    if (audioPlaying) {
      _elements.playerButtons.largeToggleBtn.children[0].className = "large-pause-btn";

      _elements.playerButtons.smallToggleBtn[_currentTrack - 1].children[0].className = "small-pause-btn";
    } else {
      _elements.playerButtons.largeToggleBtn.children[0].className = "large-play-btn";

      _elements.playerButtons.smallToggleBtn[_currentTrack - 1].children[0].className = "small-play-btn";
    }

    //Update next and previous buttons accordingly
    if (_currentTrack === 1) {
      _elements.playerButtons.previousTrackBtn.disabled = true;
      _elements.playerButtons.previousTrackBtn.className = "previous-track-btn disabled";
    } else if (_currentTrack > 1 && _currentTrack !== _elements.playListRows.length) {
      _elements.playerButtons.previousTrackBtn.disabled = false;
      _elements.playerButtons.previousTrackBtn.className = "previous-track-btn";
      _elements.playerButtons.nextTrackBtn.disabled = false;
      _elements.playerButtons.nextTrackBtn.className = "next-track-btn";
    } else if (_currentTrack === _elements.playListRows.length) {
      _elements.playerButtons.nextTrackBtn.disabled = true;
      _elements.playerButtons.nextTrackBtn.className = "next-track-btn disabled";
    }
  };

  /**
   * Updates the location of the progress indicator according to how much time left in audio.
   *
   **/
  var _updateProgressIndicator = function () {
    var currentTime = parseFloat(_elements.audio.currentTime);
    var duration = parseFloat(_elements.audio.duration);
    var indicatorLocation = 0;
    var progressBarWidth = parseFloat(_elements.progressBar.offsetWidth);
    var progressIndicatorWidth = parseFloat(_progressBarIndicator.offsetWidth);
    var progressBarIndicatorWidth = progressBarWidth - progressIndicatorWidth;

    indicatorLocation = progressBarIndicatorWidth * (currentTime / duration);

    _progressBarIndicator.style.left = indicatorLocation + "px";
  };

  /**
   * Resets all toggle buttons to be play buttons.
   *
   **/
  var _resetPlayStatus = function () {
    var smallToggleBtn = _elements.playerButtons.smallToggleBtn;

    _elements.playerButtons.largeToggleBtn.children[0].className = "large-play-btn";

    for (var i = 0; i < smallToggleBtn.length; i++) {if (window.CP.shouldStopExecution(2)) break;
      if (smallToggleBtn[i].children[0].className === "small-pause-btn") {
        smallToggleBtn[i].children[0].className = "small-play-btn";
      }
    }window.CP.exitedLoop(2);
  };

  return {
    initPlayer: initPlayer };

};

(function () {
  var player = new audioPlayer();

  player.initPlayer();
})();
//# sourceURL=pen.js
          </script>


    <div class="container">

  <audio id="audio" preload="none" tabindex="0">
    			<source src="https://archive.org/download/calexico2006-12-02..flac16/calexico2006-12-02d1t02.mp3" data-track-number="1" />
    			<source src="https://archive.org/download/ra2007-07-21/ra2007-07-21d1t05_64kb.mp3" data-track-number="2" />
    			<source src="https://archive.org/download/slac2002-02-15/slac2002-02-15d1t07_64kb.mp3" data-track-number="3" />
    			<source src="https://archive.org/download/blitzentrapper2009-02-24.flac16/blitzentrapper2009-02-24t02_64kb.mp3" data-track-number="4" />
    			<source src="https://archive.org/download/samples2003-11-21.flac16/samples2003-11-21d2t04.mp3" data-track-number="5" />    
    			<source src="https://archive.org/download/mikedoughty2004-06-16.flac16/d1t13.mp3" data-track-number="6" />
    			<source src="https://archive.org/download/glove2004-03-18.shnf/glove2004-03-18d1t05.mp3" data-track-number="7" />
    			<source src="https://archive.org/download/guster2005-11-12.flac16/guster2005-11-12d2t04.mp3" data-track-number="8" />
                                    <source src="https://archive.org/download/oar2004-11-12.flac/oar2004-11-12d1t01.mp3" data-track-number="9" />
                                    <source src="https://archive.org/download/mmj2003-09-26.shnf/mmj2003-09-26d2t08.mp3" data-track-number="10" />
    			Your browser does not support HTML5 audio.
    		</audio>

  <div class="player">

    <div class="large-toggle-btn">
      <i class="large-play-btn"><span class="screen-reader-text">Large toggle button</span></i>
    </div>
    <!-- /.play-box -->

    <div class="info-box">
      <div class="track-info-box">
        <div class="track-title-text"></div>
        <div class="audio-time">
          <span class="current-time">00:00</span> /
          <span class="duration">00:00</span>
        </div>
      </div>
      <!-- /.info-box -->

      <div class="progress-box">
        <div class="progress-cell">
          <div class="progress">
            <div class="progress-buffer"></div>
            <div class="progress-indicator"></div>
          </div>
        </div>
      </div>

    </div>
    <!-- /.progress-box -->

    <div class="controls-box">
      <i class="previous-track-btn disabled"><span class="screen-reader-text">Previous track button</span></i>
      <i class="next-track-btn"><span class="screen-reader-text">Next track button</span></i>
    </div>
    <!-- /.controls-box -->

  </div>
  <!-- /.player -->

  <div class="play-list">

    <div class="play-list-row" data-track-row="1">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        1.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="1">Calexico - Across The Wire</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="2">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        2.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="2">Ryan Adams &amp; The Cardinals - Cold Roses</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="3">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        3.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="3">The Slackers - Married Girl</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="4">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        4.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="4">Blitzen Trapper - Saturday Night</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="5">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        5.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="5">The Samples - Feel Us Shaking</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="6">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        6.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="6">Mike Doughty - American Car</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="7">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        7.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="7">G. Love &amp; Special Sauce - Dreamin'</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="8">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        8.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="8">Guster - Amsterdam</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="9">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        9.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="9">O.A.R. - About Mr. Brown</a>
      </div>
    </div>
    <div class="play-list-row" data-track-row="10">
      <div class="small-toggle-btn">
        <i class="small-play-btn"><span class="screen-reader-text">Small toggle button</span></i>
      </div>
      <div class="track-number">
        10.
      </div>
      <div class="track-title">
        <a class="playlist-track" href="#" data-play-track="10">My Morning Jacket - Phone Went West</a>
      </div>
    </div>

  </div>

  <div>Music from the <a href="https://archive.org/details/etree" target="_blank">Live Music Archive</a></div>
</div>
</asp:Content>
