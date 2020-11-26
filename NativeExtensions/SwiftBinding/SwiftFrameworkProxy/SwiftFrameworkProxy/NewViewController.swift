//
//  NewViewController.swift
//  SwiftFrameworkProxy
//
//  Created by admin on 23.11.2020.
//

import UIKit

class NewViewController: UIViewController {
    @IBOutlet private weak var titleLabel: UILabel!
     @IBOutlet private weak var closeButton: UIButton! {
        didSet {
           closeButton.addTarget(self, action:  #selector(self.closeButtonAction), for: .touchUpInside)
        }
     }
     public var model: NewModel!
     public init() {
        super.init(nibName: "NewViewController", bundle: Bundle(for: NewViewController.self))
     }
     required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
     }
     override public func viewDidLoad() {
        super.viewDidLoad()
        titleLabel.text = model.title
     }
  }
  @objc extension NewViewController {
     private func closeButtonAction() {
        self.dismiss(animated: true, completion: nil)
     }
  }
