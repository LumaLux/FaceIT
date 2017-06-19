#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Wed May 31 11:10:37 2017

@author: pracuser
"""

import cv2
import compare
import os
import sys
import select
import order
import check
#from PIL import Image
#import v4l2capture
#voor pi...

#video = v4l2capture.Video_device("/dev/video0")
#video.create_buffers(30)
#video.queue_all_buffers()
#video.start()
#eind voor pi...

if not os.path.exists("./temp"):
    os.makedirs("./temp")
cap = cv2.VideoCapture(0)
klas = sys.argv[1]
periode = sys.argv[2]

#cap.set(cv2.cv.CV_CAP_PROP_FRAME_WIDTH, 200)
#cap.set(cv2.cv.CV_CAP_PROP_FRAME_HEIGHT, 200)

#print (cap.get(cv2.cv.CV_CAP_PROP_FRAME_WIDTH))
#print (cap.get(cv2.cv.CV_CAP_PROP_FRAME_HEIGHT))

cascPath = "haarcascade_frontalface_default.xml"
faceCascade = cv2.CascadeClassifier(cascPath)
i = count = 0;

while True:
    #voor pi...
    #select.select((video,), (), ())

    #image_data = video.read_and_queue()
    #eind voor pi...
    
    os.system('cls' if os.name == 'nt' else 'clear')
    print ("Press Enter to stop process.")
    print (i)
    
    if cv2.waitKey(1) & 0xFF == ord('\r'):
        check.facecheck()
        order.facecompare(klas, periode)
        print ("done")
        break
    
    if sys.stdin in select.select([sys.stdin], [], [], 0)[0]:
        check.facecheck()
        order.facecompare(klas)
        print ("done")
        break
    i += 1

    #frame=cv2.imdecode(np.frombuffer(image_data, dtype=np.uint8), cv2.cv.CV_LOAD_IMAGE_COLOR)
    
    ret, frame = cap.read()
    
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    
    faces = faceCascade.detectMultiScale(gray, scaleFactor = 1.1, minNeighbors = 5, minSize=(30,30))
    
    print("Found {} faces".format(len(faces)))
    
    for(x, y, w, h) in faces:
        count = count+1
        crop_img = frame[y:y+h, x:x+w]
        cv2.imwrite("./temp/%02d" % (count, )+".png", crop_img)
        newimgname = "%02d" % (count, ) + ".png"
        compare.compare(newimgname)
        cv2.rectangle(frame, (x, y), (x+w, y+h), (0, 255, 0), 2)
    
    cv2.imshow('frame', frame)

cap.release()
cv2.destroyAllWindows()
