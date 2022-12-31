
var jsonViewerRawArea = "";

export function initZoomJsonViewer(string jsonText) {
    jsonViewerRawArea = document.querySelector("#jsonViewerRawArea");
    console.log(jsonText);
    jsonViewerRawArea.value = JSON.stringify(jsonText);
}

