//Font Family
let TextElement = document.getElementById("PAR");
function ChangeFont(fontName) {
  TextElement.style.fontFamily = fontName;
}

//Text Align
function ChangeAlign(alignName) {
  TextElement.style.textAlign = alignName;
}

//Line height
function ChangeHeight(lineHeightName) {
  TextElement.style.lineHeight = lineHeightName;
}

//Letter spacing
function ChangeLSpace(space) {
  TextElement.style.letterSpacing = space;
}

//Text intendent
function ChangeIndent(intendent) {
  TextElement.style.textIndent = intendent;
}

//text tranform
function ChangeTransform(tranform) {
  TextElement.style.textTransform = tranform;
}

//text decoration
function ChangeDecorate(decorate) {
  TextElement.style.textDecoration = decorate;
}

//text border
function ChangeBorder(border) {
  TextElement.style.border = border;
}

//border color
function ChangeBorderColor(color) {
  TextElement.style.borderColor = color;
}

//call functions with default values
ChangeFont("arial");
ChangeAlign("left");
ChangeHeight("normal");
ChangeLSpace("0px");
ChangeIndent("none");
ChangeDecorate("none");
ChangeBorder("none");
ChangeBorderColor("none");
