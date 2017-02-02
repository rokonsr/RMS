function OnTreeClick(evt) {
    var src = window.event != window.undefined ? window.event.srcElement : evt.target;
    var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
    var t = GetParentByTagName("table", src);
    if (isChkBoxClick) {
        var parentTable = GetParentByTagName("table", src);
        var nxtSibling = parentTable.nextSibling;
        if (nxtSibling && nxtSibling.nodeType == 1) {
            if (nxtSibling.tagName.toLowerCase() == "div") {
                CheckUncheckChildren(parentTable.nextSibling, src.checked);
            }
        }
        CheckUncheckParents(src, src.checked);
    }
}

function CheckUncheckChildren(childContainer, check) {
    var childChkBoxes = childContainer.getElementsByTagName("input");
    var childChkBoxCount = childChkBoxes.length;
    for (var i = 0; i < childChkBoxCount; i++) {
        childChkBoxes[i].checked = check;
    }
}

function CheckUncheckParents(srcChild, check) {
    var parentDiv = GetParentByTagName("div", srcChild);
    var parentNodeTable = parentDiv.previousSibling;

    if (parentNodeTable) {
        var checkUncheckSwitch;
        var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
        if (isAllSiblingsChecked) {
            checkUncheckSwitch = true;
        }
        else {
            checkUncheckSwitch = false;
        }
        var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
        if (inpElemsInParentTable.length > 0) {
            var parentNodeChkBox = inpElemsInParentTable[0];
            parentNodeChkBox.checked = checkUncheckSwitch;

            CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
        }
    }
}

function AreAllSiblingsChecked(chkBox) {
    var parentDiv = GetParentByTagName("div", chkBox);
    var childCount = parentDiv.childNodes.length;
    var k = 0;
    for (var i = 0; i < childCount; i++) {
        if (parentDiv.childNodes[i].nodeType == 1) {
            if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                //if any of sibling nodes are not checked, return false
                if (prevChkBox.checked) {
                    //add each selected node one value
                    k = k + 1;
                }
            }
        }
    }

    //Finally check any one of child node is select if selected yes then return ture parent node check

    if (k > 0) {
        return true;
    }
    else {
        return false;
    }
}
function GetParentByTagName(parentTagName, childElementObj) {
    var parent = childElementObj.parentNode;
    while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
        parent = parent.parentNode;
    }
    return parent;
}