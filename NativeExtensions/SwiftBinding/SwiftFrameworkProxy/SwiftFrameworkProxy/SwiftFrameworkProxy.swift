import Foundation
import UIKit

@objc(SwiftFrameworkProxy)
public class SwiftFrameworkProxy : NSObject {

    @objc
    public func getValue() -> String {
        return "Hello world!"
    }
    
    @objc
    public func getViewController() -> UIViewController {
        let vc = NewViewController()
        vc.model = NewModel(title: "Hello world!")
        return vc
    }
    
}
