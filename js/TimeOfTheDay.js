function typeWriter(text) {
    let hlElement = document.getElementById("hl");
    let splitTxt = text.split('')
    for (let i = 0; i < splitTxt.length; i++) {
        (function (i) {
            setTimeout(function () {
                hlElement.innerHTML += splitTxt[i]
            }, 75 * i);
        })(i);
    };
}

window.onload = function () {
    let curDate = new Date();

    if (curDate.getHours() >= 19 || curDate.getHours() < 2) {
        /* Evening Time */
        document.getElementById("Home").classList.add('EveningGradient');
        document.getElementById("AboutMe").classList.add('EveningGradient');
        document.getElementById('FirstBackground').style.backgroundImage = 'url(../images/Wallpaper/Wallpaper1.jpg)';
        console.log('Evening Theme');

        typeWriter(window.location.toString().includes('index_DE.html') ?
            "Genieße deinen Abend" : "Enjoy your evening");
    }
    else if (curDate.getHours() < 12) {
        /* Morning Time */
        document.getElementById("Home").classList.add('MorningGradient');
        document.getElementById("AboutMe").classList.add('MorningGradient');
        document.getElementById('FirstBackground').style.backgroundImage = 'url(../images/Wallpaper/MorningWallpaper2.jpg)';
        console.log('Morning Theme');

        typeWriter(window.location.toString().includes('index_DE.html') ?
            "Guten Morgen" : "Good morning");
    }
    else {
        /* Day Time */
        document.getElementById("Home").classList.add('DayGradient');
        document.getElementById("AboutMe").classList.add('DayGradient');
        document.getElementById('FirstBackground').style.backgroundImage = 'url(../images/Wallpaper/CafeWallpaper2.jpg)';
        console.log('Day Theme');

        typeWriter(window.location.toString().includes('index_DE.html') ?
            "Hoffe Du hast einen schönen Tag" : "Hope you're having a good day");
    }
};
