# Azure Functions Face Recognition Sample #

This provides sample codes for face recognition using [Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-overview?WT.mc_id=devkimchicom-github-juyoo), for [Power Apps](https://powerapps.microsoft.com/?WT.mc_id=devkimchicom-github-juyoo)


## Readings ##

* 한국어
  * [[COVID-19 시리즈 #1] 애저 펑션을 이용해서 브라우저에서 애저 Blob 저장소로 스크린샷 이미지 저장하기](https://blog.aliencube.org/ko/2020/04/01/capturing-images-from-browser-to-azure-blob-storage-via-azure-functions/)
* English
  * [[COVID-19 Series #1] Capturing Face Images from Browser to Azure Blob Storage via Azure Functions](https://devkimchi.com/2020/04/01/capturing-images-from-browser-to-azure-blob-storage-via-azure-functions/)


## Prerequisites ##

* Webcam


## Getting Started ##

### App Settings ###

Setup your [App Settings blade](https://docs.microsoft.com/azure/app-service/configure-common?WT.mc_id=devkimchicom-github-juyoo) on [Azure](https://azure.microsoft.com/features/azure-portal/?WT.mc_id=devkimchicom-github-juyoo), or `local.settings.json` on your local machine.

* `Blob__SasToken`: The SAS token for the blob container so that the Face API can access to the blob images.
* `Blob__Container`: The container name of your [Azure Blob Storage](https://docs.microsoft.com/azure/storage/blobs/storage-blobs-overview?WT.mc_id=devkimchicom-github-juyoo).
* `Blob__PersonGroup`: The person group name of your face photos to be stored.
* `Blob__NumberOfPhotos`: The number of photos to be used for face identification.
* `Table__Name`: The name of the table storage that stores the face identification history.
* `Face__AuthKey`: The subscription key for the Face API.
* `Face__Endpoint`: The endpoint for the Face API.
* `Face__Confidence`: The confidence level fo the face identification. The maximum value is `1`.


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work with corresponding tests, please send us a pull request onto our `master` branch for review.


## License ##

This is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2019 [Dev Kimchi](https://devkimchi.com)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
