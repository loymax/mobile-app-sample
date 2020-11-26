using Foundation;
using UIKit;

namespace Binding
{
	// @interface SwiftFrameworkProxy : NSObject
	[BaseType (typeof(NSObject))]
	interface SwiftFrameworkProxy
	{
		// -(NSString * _Nonnull)getValue __attribute__((warn_unused_result("")));
		[Export ("getValue")]
		[Verify (MethodToProperty)]
		string Value { get; }

		// -(UIViewController * _Nonnull)getViewController __attribute__((warn_unused_result("")));
		[Export ("getViewController")]
		[Verify (MethodToProperty)]
		UIViewController ViewController { get; }
	}
}
