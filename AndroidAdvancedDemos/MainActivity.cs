using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Google.AR.Sceneform.UX;
using Google.AR.Sceneform.Rendering;
using System;
using Google.AR.Core;
using Android.Views;
using Google.AR.Sceneform;
using Google.AR.Sceneform.Math;
using Java.Util.Concurrent;

namespace AndroidAdvancedDemos
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ArFragment arFragment;
        private ModelRenderable modelRenderable;
        private Material readyColor;
        private static Material failedColor;
        private static Material foundColor;
        private static Material savedColor;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            arFragment = (ArFragment)this.SupportFragmentManager.FindFragmentById(Resource.Id.fragmentAR);

            //setUpModel();
            setUpPlane();


            MaterialFactory.MakeOpaqueWithColor(this, new Color(Android.Graphics.Color.Red)).GetAsync().ContinueWith(materialTask => failedColor = (Material)materialTask.Result);
            MaterialFactory.MakeOpaqueWithColor(this, new Color(Android.Graphics.Color.Green)).GetAsync().ContinueWith(materialTask => savedColor = (Material)materialTask.Result);
            MaterialFactory.MakeOpaqueWithColor(this, new Color(Android.Graphics.Color.Yellow)).GetAsync().ContinueWith(materialTask =>
            {
                readyColor = (Material)materialTask.Result;
                foundColor = readyColor;
            });

        }

        private void setUpModel()
        {
            ModelRenderable.InvokeBuilder()
            .SetSource(this,AndroidAdvancedDemos.Resource.Raw.wolves)
            .Build((renderable) =>
            {
                this.modelRenderable = renderable;
            });
        }
        private void setUpPlane()
        {
            arFragment.TapArPlane += (sender, args) => this.OnTapArPlaneListener(args.HitResult, args.Plane, args.MotionEvent);
        }

        private void OnTapArPlaneListener(HitResult hitResult, Plane plane, MotionEvent motionEvent)
        {
            Anchor anchor = hitResult.CreateAnchor();
            AnchorNode anchorNode = new AnchorNode(anchor);
            anchorNode.SetParent(arFragment.ArSceneView.Scene);
            createModel(anchorNode);
            
        }
        private void createModel(AnchorNode anchorNode)
        {
            Google.AR.Sceneform.UX.TransformableNode node = new TransformableNode(arFragment.TransformationSystem);
            node.SetParent(anchorNode);
            var nodeRenderable = ShapeFactory.MakeSphere(0.08f, new Vector3(0.0f, 0.15f, 0.0f),readyColor);
            node.Renderable = nodeRenderable;
                //modelRenderable;
                ////;
            node.Select();


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}