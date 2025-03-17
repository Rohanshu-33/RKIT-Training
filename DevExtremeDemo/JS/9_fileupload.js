$(document).ready(function () {

    // ajax file upload
    $("#fileUploaderContainer").dxFileUploader({
        name: "file",  // this will be required to access the files on the server
        multiple: true,
        uploadMode: "useButtons", // or "instantly", useForms
        uploadUrl: "https://api.escuelajs.co/api/v1/files/upload",
        allowedFileExtensions: [".html", ".png"],
        accept: "image/*",
        uploadHeaders: {
            YourHeaderName: "YourHeaderValue"
        },

        // dropZone: <html element to be used as a drop zone>

        invalidFileExtensionMessage: "wrong file extension",
        invalidMaxFileSizeMessage: "max file size crossed",
        invalidMinFileSizeMessage: "minimum file size not achieved",
        minFileSize: 1024, // 1 KB
        maxFileSize: 1024 * 1024, // 1 MB
        labelText: "drag and drop your files here", // like a placeholder at the dropping zone
        onBeforeSend: function (e) {
            console.log("Triggers before file sending");
        },
        onContentReady: function (e) {
            console.log("Content ready", e);
        },
        onDropZoneEnter: function (e) {
            console.log("Entered dropping zone.", e);
        },
        onDropZoneLeave: function (e) {
            console.log("Leaving dropping zone.", e);
        },
        onFilesUploaded: function (e) {
            console.log("All files are uploaded.", e);  // triggers once
        },
        onUploaded: function (e) {
            console.log("All files are uploaded 2.", e);  // triggers with every file upload in multiple uploads
        },
        onProgress: function (e) {
            console.log("progress: ", e);
        },
        onUploadAborted: function (e) {
            console.log("Aborted. ", e);
        },
        // onUploadError
        // onUploadStarted
        readyToUploadMessage: "File can now be uploaded", // default: "ready to upload"
        selectButtonText: "Add file",
        showFileList: true,
        // uploadAbortedMessage: "Upload aborted",  // not executing
        // uploadButtonText: "Upload file",
        // uploadChunk // A function that uploads a file in chunks. Return Value: Promise<any>
        // uploadFile
        // uploadHeaders
    });

    // html form file upload
    $("#fileUploaderContainer2").dxFileUploader({
        multiple: true,
        name: "files[]",
        uploadMode: "useForm",
        uploadUrl: "https://api.escuelajs.co/api/v1/files/upload",
        // chunkSize: 400000, // 400 KB chunks of a large file
        // allowCanceling: true, --? wont be applied if uploadMode is useForm (submit button of the form)
    });


    $("#btn").dxButton({
        text: "Submit",
        type: "default",
        useSubmitBehaviour: true,  // checks form validation of validation group. if onclick is present, it is triggered before validation and form submission
        onClick: function () {
            $("#myForm")[0].submit();  // Accessing form element directly
            alert("success");
        }
    });

    var uploadControl = $("#fileUploaderContainer").dxFileUploader("instance");
    setTimeout(() => {
        uploadControl.upload();
    }, 7000);
});