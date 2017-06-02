#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Thu Jun  1 11:48:49 2017

@author: joey
"""

import cv2
import time

cap = cv2.VideoCapture(0)

cascPath = "haarcascade_frontalface_default.xml"
faceCascade = cv2.CascadeClassifier(cascPath)
count = count2 = 0;
try:
    while(True):
        ret, frame = cap.read()
    
        gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
        
        faces = faceCascade.detectMultiScale(gray, scaleFactor = 1.1, minNeighbors = 5, minSize=(30,30))
        
        print("Found {} faces".format(len(faces)))
        
        for(x, y, w, h) in faces:
            count = count+1
            crop_img = frame[y:y+h, x:x+w]
            cv2.imwrite("temp/%02d" % (count, )+".png", crop_img)
            cv2.rectangle(frame, (x, y), (x+w, y+h), (0, 255, 0), 2)
            
            cv2.imshow('frame', frame)
            time.sleep(0.067)
            if cv2.waitKey(1) & 0xFF == ord('q'):
                break
            
    cap.release()
    cv2.destroyAllWindows()
except KeyboardInterrupt:
    pass