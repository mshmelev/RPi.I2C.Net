SHELL = /bin/sh
CC    = gcc
FLAGS        = -c -Wall -Werror -fpic
DEBUGFLAGS   = -O0 -D _DEBUG
RELEASEFLAGS = -O2 -D NDEBUG

TARGET  = libnativei2c.so
SOURCES = $(shell echo *.c)
HEADERS = $(shell echo *.h)
OBJECTS = $(SOURCES:.c=.o)

PREFIX = $(DESTDIR)/usr/local
BINDIR = $(PREFIX)/bin

all:
	$(CC) $(FLAGS) $(RELEASEFLAGS) $(SOURCES)
	$(CC) -shared -o $(TARGET) $(OBJECTS)

