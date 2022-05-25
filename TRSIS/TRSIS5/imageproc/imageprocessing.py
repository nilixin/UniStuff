import base64
import io
import PIL.ImageOps as iops
from PIL import Image

# изменение ширины и высоты по указанным конечным величинам
def resized(width, height, image_binary):
    image_initial_bin = decode(image_binary)
    image = Image.open(io.BytesIO(image_initial_bin))

    image_proc = image.resize((width, height))

    image_final_bin = encode(image_proc)
    return image_final_bin

# изменение ширины и высоты по указанному количеству раз
def resized_by(times, image_binary):
    image_initial_bin = decode(image_binary)
    image = Image.open(io.BytesIO(image_initial_bin))

    (width, height) = (int(image.width * times), int(image.height * times))
    image_proc = image.resize((width, height))

    image_final_bin = encode(image_proc)
    return image_final_bin

def cropped(from_left, from_upper, from_right, from_lower, image_binary):
    image_initial_bin = decode(image_binary)
    image = Image.open(io.BytesIO(image_initial_bin))

    (left, upper, right, lower) = (0 + from_left, 0 + from_upper, image.width - from_right, image.height - from_lower)
    image_proc = image.crop((left, upper, right, lower))

    image_final_bin = encode(image_proc)
    return image_final_bin

def rotated(angle, image_binary):
    image_initial_bin = decode(image_binary)
    image = Image.open(io.BytesIO(image_initial_bin))

    image_proc = image.rotate(angle)

    image_final_bin = encode(image_proc)
    return image_final_bin

def flipped(image_binary):
    image_initial_bin = decode(image_binary)
    image = Image.open(io.BytesIO(image_initial_bin))

    image_proc = iops.flip(image)

    image_final_bin = encode(image_proc)
    return image_final_bin

def mirrored(image_binary):
    image_initial_bin = decode(image_binary)
    image = Image.open(io.BytesIO(image_initial_bin))

    image_proc = iops.mirror(image)

    image_final_bin = encode(image_proc)
    return image_final_bin

def pasted(image_binary, background_binary):
    image_initial_bin = decode(image_binary)
    image = Image.open(io.BytesIO(image_initial_bin))
    background_initial_bin = decode(background_binary)
    background = Image.open(io.BytesIO(background_initial_bin))

    image_proc = Image.new('RGBA', (background.width, background.height), (0, 0, 0, 0))
    image_proc.paste(background, (0, 0))
    try: # блок try-except потому что генерирует исключение если у image будет нарушена прозрачность
        image_proc.paste(image, (0, 0), image)
    except:
        pass

    image_final_bin = encode(image_proc)
    return image_final_bin

# декодирование присланного битового str в ASCII, в str в битовом формате
def decode(binary):
    return base64.decodebytes(binary)

# кодирование объекта PIL.Image в битовый массив
def encode(image):
    image_proc_bin = io.BytesIO()
    image.save(image_proc_bin, format='PNG')
    image_proc_bin = image_proc_bin.getvalue()
    return base64.encodebytes(image_proc_bin)