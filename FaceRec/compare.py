from PIL import Image
from PIL import ImageChops

import os

def compare(materialname):
    print("start")
    for filename2 in sorted(os.listdir("./temp")):
        if filename2 == "difference.png" or filename2 == materialname or materialname == "01.png":
            continue
        elif filename2.endswith(".png") and os.path.isfile("./temp/" + filename2):
            img2 = Image.open("./temp/" + materialname)
            img1 = Image.open("./temp/" + filename2)
                    
            diff = ImageChops.difference(img1, img2)
            diff = diff.convert('L')
                    
            pixels = diff.getdata()
            threshold = 25
            black = 0
            for pixel in pixels:
                if pixel < threshold:
                    black += 1
            
                else:
                    continue
            amount = len(pixels)            
            percentage = (black / float(amount)) * 100  
                
            if percentage > float(80):
                print (str(percentage))
                os.remove("./temp/" + filename2)
                    
            else:
                continue
