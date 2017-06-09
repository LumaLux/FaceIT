from PIL import Image

im1 = Image.open("38.png")

im2 = im1.point(lambda p: p * 1.5)

im2.show()

im2.save("niels.png")

