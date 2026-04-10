window.downloadFileFromBase64 = (base64String, fileName, mimeType) => {
    const bytes = atob(base64String);
    const byteNumbers = new Array(bytes.length);
    for (let i = 0; i < bytes.length; i++) {
        byteNumbers[i] = bytes.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: mimeType });
    
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = fileName;
    link.style.display = 'none';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    window.URL.revokeObjectURL(link.href);
};