AddAltToImg = function (n, t) {
    var i = $(n, t); i.attr("alt",
        i.attr("id").replace(/ID/, ""))
}