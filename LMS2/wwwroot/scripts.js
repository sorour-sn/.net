
function onImageChange(e) {
    const imageNode = document.getElementById('book-image')
    const url = window.URL.createObjectURL(e.target.files[0])
    if (imageNode && url) {
      imageNode.src = url;
    }
    
}