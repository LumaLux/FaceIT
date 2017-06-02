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
import time
cap = cv2.VideoCapture(0)

cascPath = "haarcascade_frontalface_default.xml"
faceCascade = cv2.CascadeClassifier(cascPath)
i = count = 0;

while True:
    
    os.system('cls' if os.name == 'nt' else 'clear')
    print ("Press Enter to stop process.")
    print (i)
    if sys.stdin in select.select([sys.stdin], [], [], 0)[0]:
        datetime = time.strftime("%c")
        os.makedirs("./Processed/" + datetime)
        for filename in os.listdir("./temp/"):
            if filename.endswith(".png"):
                os.rename("./temp/" + filename, "./Processed/" + datetime + "/" + filename)
        print (datetime)
        line = raw_input()
        break
    i += 1
    
    ret, frame = cap.read()
    
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    
    faces = faceCascade.detectMultiScale(gray, scaleFactor = 1.1, minNeighbors = 5, minSize=(30,30))
    
    print("Found {} faces".format(len(faces)))
    
    for(x, y, w, h) in faces:
        count = count+1
        crop_img = frame[y:y+h, x:x+w]
        cv2.imwrite("temp/%02d" % (count, )+".png", crop_img)
        newimgname = "%02d" % (count, ) + ".png"
        compare.compare(newimgname)
        
        
        cv2.rectangle(frame, (x, y), (x+w, y+h), (0, 255, 0), 2)
    
    cv2.imshow('frame', frame)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()