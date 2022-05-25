import io
from django.http import HttpResponse
from django.shortcuts import render
from imageproc.forms import UploadForm
from zipfile import ZipFile
import base64

import imageproc.imageprocessing as imp

images = list()

def image_upload(request):
    global images

    if request.method == 'POST': # заходит сюда, после того как пользователь выбрал изображение(я)
        uploadform = UploadForm(request.POST, request.FILES)
        if uploadform.is_valid():
            image_proc(request)

            return render(request, 'result.html', {'images': images})
        else:
            return HttpResponse(content='<h1>not valid</h1>')
    else: 
        if len(images) == 0: # заходит сюда в самом начале или переходит сюда в самом конце
            uploadform = UploadForm
            return render(request, 'index.html', {'uploadform': uploadform})
        else: # заходит сюда, когда пользовтель на странице с обработанными изображениями нажал кнопку "Скачать"
            buffer = io.BytesIO()
            z = ZipFile(buffer, 'w')

            for i, image in enumerate(images):
                with z.open(f'{i}.png', 'w') as img:
                    img.write(base64.b64decode(image))

            response = HttpResponse(buffer.getvalue())
            response['Content-Type'] = 'application/x-zip-compressed'
            response['Content-Disposition'] = 'attachment; filename=images.zip'
            
            images.clear()

            return response

def image_proc(request):
    global images
            
    ### Обработка оригинала
    
    original_image = request.FILES['image']
    original_image_bin = base64.b64encode(original_image.read())
    original_image_str = original_image_bin.decode('ascii')
    images.append(original_image_str)

    original_background_bin = None
    original_background = request.FILES['background'] if 'background' in request.FILES else None # если background не выбран, то фоном будет image, да настолько коряво 🤷🤷
    if original_background is not None:
        original_background_bin = base64.b64encode(original_background.read())
    else:
        original_background_bin = original_image_bin

    ### Выполнение заданий

    # 0 Изменение размера изображения
    resized_image_bin = imp.resized(1000, 200, original_image_bin)
    resized_image_str = resized_image_bin.decode('ascii')
    images.append(resized_image_str)

    # 1 Изменение размера изображения
    resizedby_image_bin = imp.resized_by(0.5, original_image_bin)
    resizedby_image_str = resizedby_image_bin.decode('ascii')
    images.append(resizedby_image_str)

    # 2 Обрезка изображения слева
    cropped_image_bin = imp.cropped(50, 50, 0, 0, original_image_bin)
    cropped_image_str = cropped_image_bin.decode('ascii')
    images.append(cropped_image_str)

    # 3 Поворот изображения
    rotated_image_bin = imp.rotated(45.0, original_image_bin)
    rotated_image_str = rotated_image_bin.decode('ascii')
    images.append(rotated_image_str)

    # 4 Переворот изображения
    flipped_image_bin = imp.flipped(original_image_bin)
    flipped_image_str = flipped_image_bin.decode('ascii')
    images.append(flipped_image_str)

    # 5 Отражение изображения
    mirrored_image_bin = imp.mirrored(original_image_bin)
    mirrored_image_str = mirrored_image_bin.decode('ascii')
    images.append(mirrored_image_str)

    # 6 Вставка изображения поверх другого
    pasted_image_bin = imp.pasted(original_image_bin, original_background_bin)
    pasted_image_str = pasted_image_bin.decode('ascii')
    images.append(pasted_image_str)
