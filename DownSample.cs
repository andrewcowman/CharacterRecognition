using System.Drawing;

namespace CharacterRecognition {
    class DownSample {
        private readonly Bitmap image;
        private int _downSampleBottom;
        private int _downSampleLeft;
        private int _downSampleRight;
        private int _downSampleTop;

        private double _ratioX, _ratioY;

        public DownSample(Bitmap image) {
            this.image = image;
        }

        public double[] DoDownSampling(int downSampleWidth, int downSampleHeight) {
            int size = downSampleHeight * downSampleWidth;
            var result = new double[size];

            FindBounds();

            _ratioX = (_downSampleRight - _downSampleLeft)/(double)downSampleWidth;
            _ratioY = (_downSampleBottom - _downSampleTop)/(double)downSampleHeight;

            int index = 0;
            for(int y = 0; y < downSampleHeight; y++) {
                for(int x = 0; x < downSampleWidth; x++) {
                    result[index++] = DownSampleRegion(x, y);
                }
            }

            return result;
        }

        protected double DownSampleRegion(int x, int y) {
            var startX = (int)(_downSampleLeft + (x * _ratioX));
            var startY = (int)(_downSampleTop + (y * _ratioY));
            var endX = (int)(startX + _ratioX);
            var endY = (int)(startY + _ratioY);

            for(int yy = startY; yy <= endY; yy++) {
                for(int xx = startX; xx <= endX; xx++) {
                    Color pixel = image.GetPixel(xx, yy);
                    if(IsBlack(pixel)) {
                        return 1;
                    }
                }
            }

            return 0;
        }

        protected void FindBounds() {
            int h = image.Height;
            int w = image.Width;

            for(int y = 0; y < h; y++) {
                if(!HLineClear(y)) {
                    _downSampleTop = y;
                    break;
                }
            }

            for(int y = h - 1; y >= 0; y--) {
                if(!HLineClear(y)) {
                    _downSampleBottom = y;
                    break;
                }
            }

            for(int x = 0; x < w; x++) {
                if(!VLineClear(x)) {
                    _downSampleLeft = x;
                    break;
                }
            }

            for(int x = w - 1; x >= 0; x--) {
                if(!VLineClear(x)) {
                    _downSampleRight = x;
                    break;
                }
            }
        }

        protected bool HLineClear(int y) {
            int w = image.Width;
            for(int i = 0; i < w; i++) {
                Color pixel = image.GetPixel(i, y);
                if(IsBlack(pixel)) {
                    return false;
                }
            }
            return true;
        }

        protected bool VLineClear(int x) {
            int h = image.Height;
            for(int i = 0; i < h; i++) {
                Color pixel = image.GetPixel(x, i);
                if(IsBlack(pixel)) {
                    return false;
                }
            }
            return true;
        }

        protected bool IsBlack(Color color) {
            return (color.R != 255 || color.G != 255 || color.B != 255);
        }
    }
}
