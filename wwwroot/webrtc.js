window.startVideoCall = function () {
    const video = document.getElementById('localVideo');
    navigator.mediaDevices.getUserMedia({ video: true, audio: true })
        .then(stream => {
            video.srcObject = stream;
        })
        .catch(error => {
            console.error('Ошибка доступа к камере и микрофону: ', error);
        });
}
